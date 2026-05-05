using System.Collections;
using UnityEngine;
using Pathfinding; 

public class EmployeePathFinder : MonoBehaviour
{
    public QueueSystem queueSystem; 
    private AIDestinationSetter aiDestinationSetter;
    
    public Transform ownDesk;
    private int myCurrentIndex = -1; 
    private bool isWaitingAtFront = false; 

    void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
    }

    
    public void GoToQueue()
    {
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

        while (Vector3.Distance(transform.position, targetSpot.position) > 0.5f)
        {
            yield return null;
        }

        float randomWait = Random.Range(2f, 5f);
        yield return new WaitForSeconds(randomWait);

        FinishTask();
    }

    public void FinishTask()
    {
        isWaitingAtFront = false;
        queueSystem.LeaveQueue(this);
        if (ownDesk != null)
        {
            aiDestinationSetter.target = ownDesk;
            GetComponent<Employee>(). needsHelp = false;
        }
    }
}