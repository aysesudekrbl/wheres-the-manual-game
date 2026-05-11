using System.Collections;
using UnityEngine;
using Pathfinding; 

public class EmployeePathFinder : MonoBehaviour
{
    public QueueSystem queueSystem; 
    private AIDestinationSetter aiDestinationSetter;
    private PrinterController printer;
    
    public bool headingToDesk = false;
    public Transform ownDesk;
    private int myCurrentIndex = -1; 
    private bool isWaitingAtFront = false; 
    

    void Awake()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        printer = FindObjectOfType<PrinterController>();

        if (queueSystem == null)
        {
            queueSystem = FindObjectOfType<QueueSystem>(); 
        }
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

        while (printer.outOfInk)
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

        PrinterController printer = queueSystem.GetComponent<PrinterController>();
        if (printer != null)
        {
            printer.OnEmployeeFinished();
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