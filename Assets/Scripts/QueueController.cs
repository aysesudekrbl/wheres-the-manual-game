using System.Collections.Generic;
using UnityEngine;

public class QueueSystem : MonoBehaviour
{
    // 4 sarı elmasını buraya sürükle
    public Transform[] queueSpots; 
    
    
    public List<EmployeePathFinder> currentQueue = new List<EmployeePathFinder>();

  
    public void JoinQueue(EmployeePathFinder employee)
    {
        
        if (currentQueue.Count < queueSpots.Length)
        {
            currentQueue.Add(employee);
            UpdateQueuePositions(); 
        }

    }

    public void LeaveQueue(EmployeePathFinder employee)
    {
        if (currentQueue.Contains(employee))
        {
            currentQueue.Remove(employee);
            UpdateQueuePositions(); 
        }
    }

    
    private void UpdateQueuePositions()
    {
        for (int i = 0; i < currentQueue.Count; i++)
        {
            
            currentQueue[i].UpdateTarget(queueSpots[i], i);
        }
    }
}