using System.Collections;
using UnityEngine;
using Pathfinding; 

public class EmployeePathFinder : MonoBehaviour
{
    public QueueSystem queueSystem; 
    private AIDestinationSetter aiDestinationSetter;
    
    private Animator anim;

    public bool headingToDesk = false;
    public Transform ownDesk;
    private int myCurrentIndex = -1; 
    private bool isWaitingAtFront = false; 
    

    void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
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
        aiDestinationSetter.target = newTarget; 

        if (myCurrentIndex == 0 && !isWaitingAtFront)
        {
            StartCoroutine(WaitAtFrontRoutine(newTarget));
        }
    }

    private IEnumerator WaitAtFrontRoutine(Transform targetSpot)
    {
        isWaitingAtFront = true;

        while (Vector3.Distance(transform.position, targetSpot.position) > 1.0f)
        {
            yield return null;
        }

        

        IWorkStation station = queueSystem.GetComponent<IWorkStation>();
        if (station != null)
        {
            if (station.IsBroken) anim.SetBool("Waiting", true);

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
        if (ownDesk != null)
        {
            aiDestinationSetter.target = ownDesk;
            headingToDesk = true;

            StartCoroutine(ReturnToDeskRoutine());
        }
    }


    private IEnumerator ReturnToDeskRoutine()
    {
        while (Vector3.Distance(transform.position, ownDesk.position) > 0.5f)
        {
            yield return null;
        }

        headingToDesk = false;
        GetComponent<Employee>().needsHelp = false;
    }
}