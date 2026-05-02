using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Employee : MonoBehaviour,IInteractable
{
    public InteractGroup Group => InteractGroup.Work;
    private SpriteRenderer sr;
    private Color originalColor;

    public Sprite mail;


    //Generating Tasks
    public float minWaitTime = 2f;
    public float maxWaitTime = 5f;
    public SpriteRenderer computer;
    public Sprite mailTask;
    public Sprite overheatTask;
    public Sprite noTask;
    public bool needsHelp = false;
    public bool isManagerHere = false;
    private float fanWaitTime = 0f;
    
    private ManagerCarry playerManager;
    
    public enum EmployeeTask
    {
        None,
        Mail,
        Overheat
    }

    public EmployeeTask currentTask = EmployeeTask.None;

    private void Start()
    {
    StartCoroutine(RandomTaskRoutine());
    }

    private IEnumerator RandomTaskRoutine()
    {
        while (true) 
        {
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            if (!needsHelp)
            {
                GenerateRandomTask(); 
            }
        }
    }

    public void GenerateRandomTask()
    {
        int randomnumber = Random.Range(1,3);
        currentTask = (EmployeeTask)randomnumber;
        needsHelp = true;

        switch (currentTask)
    {
        case EmployeeTask.Mail:
            computer.sprite = mailTask;
            break;

        case EmployeeTask.Overheat:
            computer.sprite = overheatTask;
            break;

    }
    }

    

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        playerManager = FindObjectOfType<ManagerCarry>();
    }

    public void Interact(Transform interactorTransform)
    {
        ManagerCarry managerCarry = interactorTransform.GetComponent<ManagerCarry>();
        
        if (managerCarry != null && !managerCarry.isHandFull)
        {
            if (currentTask == EmployeeTask.Mail){
                managerCarry.PickUpItem("Post", mail, CarrySlot.Hand);
                currentTask = EmployeeTask.None;
                computer.sprite = noTask;
                needsHelp = false;
            }
        }
    }

    public void Update()
    {
        
        if (isManagerHere && currentTask == EmployeeTask.Overheat && playerManager.currentHeadtem == "Fan")
        {
            fanWaitTime += Time.deltaTime;
            if (fanWaitTime > 3f)
            {
                fanWaitTime = 0f;
                currentTask = EmployeeTask.None;
                computer.sprite = noTask;
                needsHelp = false;
            }
        }
        else
        {
            fanWaitTime = 0f;
        }
    }
    public void onNotTouchingPlayer()
    {
        sr.color = originalColor;
        isManagerHere = false;
        fanWaitTime = 0f;
    }
    

    public void onTouchingPlayer()
    {
        sr.color = Color.red;
        isManagerHere = true;

    }


    
}