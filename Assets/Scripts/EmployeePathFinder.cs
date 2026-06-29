using System.Collections;
using UnityEngine;
using Pathfinding; 

public class EmployeePathFinder : MonoBehaviour
{
    public QueueSystem queueSystem; 
    private AIDestinationSetter aiDestinationSetter;
    private Pathfinding.AIPath aiPath;

    private Animator anim;

    public bool headingToDesk = false;
    public Transform ownDesk;
    private int myCurrentIndex = -1; 
    private bool isWaitingAtFront = false; 

    [Header("Stuck Detection")]
    public float stuckVelocityThreshold = 0.05f; // bu hızın altı "duruyor" sayılır
    public float stuckTimeLimit = 4f;            // bu kadar süre hareketsiz kalırsa "takıldı" say

    void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        aiPath = GetComponent<Pathfinding.AIPath>();
        anim = GetComponent<Animator>();
    }

    
    public void GoToQueue(QueueSystem targetQueue)
    {
        queueSystem = targetQueue;
        queueSystem.JoinQueue(this);
    }


    public void UpdateTarget(Transform newTarget, int newIndex)
    {
        myCurrentIndex = newIndex;

        if (!isWaitingAtFront)
        {
            aiDestinationSetter.target = newTarget;
        }

        if (myCurrentIndex == 0 && !isWaitingAtFront)
        {
            StartCoroutine(WaitAtFrontRoutine(newTarget));
        }
    }

    
    private IEnumerator WaitUntilArrived(Transform targetSpot, float arriveDistance)
    {
        float stuckTimer = 0f;

        while (Vector3.Distance(transform.position, targetSpot.position) > arriveDistance)
        {
            if (aiPath.velocity.magnitude < stuckVelocityThreshold)
            {
                stuckTimer += Time.deltaTime;
                if (stuckTimer >= stuckTimeLimit)
                {
                    Debug.LogWarning(gameObject.name + " gerçekten takıldı, zorla devam ediliyor.");
                    yield break; // gerçekten takılı kaldıysa döngüden çık
                }
            }
            else
            {
                stuckTimer = 0f; // hareket ediyorsa sayaç sıfırlanır, ne kadar uzun sürerse sürsün bekler
            }

            yield return null;
        }
    }

    private IEnumerator WaitAtFrontRoutine(Transform targetSpot)
    {
        isWaitingAtFront = true;

        yield return StartCoroutine(WaitUntilArrived(targetSpot, 1.0f));

        IWorkStation station = queueSystem.GetComponent<IWorkStation>();
        if (station != null)
        {
            if (station.IsBroken)
            {
                anim.SetBool("Waiting", true);
            }

            while (station.IsBroken)
            {
                yield return null; 
            }
            anim.SetBool("Waiting", false);

            float timer = 0f;
            while (timer < station.WorkDuration)
            {
                if (!station.IsBroken) 
                {
                    timer += Time.deltaTime;
                    anim.SetBool("Waiting", false); 
                }
                else 
                {
                    anim.SetBool("Waiting", true);
                }
                
                yield return null; 
            }
        }
        
        FinishTask();
    }

    public void FinishTask()
    {
        isWaitingAtFront = false;

        IWorkStation station = queueSystem.GetComponent<IWorkStation>();
        if (station != null)
        {
            station.OnEmployeeFinished();
        }

        queueSystem.LeaveQueue(this);

        Employee emp = GetComponent<Employee>();
        emp.currentTask = Employee.EmployeeTask.None;
        emp.computer.sprite = emp.noTask;

        if (ownDesk != null)
        {
            aiDestinationSetter.target = ownDesk;
            headingToDesk = true;
            StartCoroutine(ReturnToDeskRoutine());
        }
    }


    private IEnumerator ReturnToDeskRoutine()
    {
        yield return StartCoroutine(WaitUntilArrived(ownDesk, 0.5f));

        headingToDesk = false;
        GetComponent<Employee>().needsHelp = false;
    }
}