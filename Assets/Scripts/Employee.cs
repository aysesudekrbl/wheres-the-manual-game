using System.Collections;
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
    private float coffeeCount = 0;
    
    public QueueSystem printerQueue;
    public QueueSystem bossQueue;
    private ManagerCarry playerManager;

    private float sleepCooldown = 0f;
    private float angerCooldown = 0f;
    //Animation

    private Pathfinding.AIPath aiPath;
    private Animator anim;
    
    public enum EmployeeTask
    {
        None,
        Mail,
        Overheat,
        Printer,
        BossDuty
    }

    public EmployeeTask currentTask = EmployeeTask.None;

     private void Awake()
    {

        printerQueue = GameObject.Find("Printer").GetComponent<QueueSystem>();
        bossQueue = GameObject.Find("BossChair").GetComponent<QueueSystem>();
        
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        playerManager = FindFirstObjectByType<ManagerCarry>();

        aiPath = GetComponent<Pathfinding.AIPath>();
        anim = GetComponent<Animator>();
    }
     
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
        int randomnumber = Random.Range(1,5);
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
        
        case EmployeeTask.Printer:
            GetComponent<EmployeePathFinder>().GoToQueue(printerQueue);
            break;

        case EmployeeTask.BossDuty:
           GetComponent<EmployeePathFinder>().GoToQueue(bossQueue);
            break;
    }
    }



    public void Interact(Transform interactorTransform)
    {
        ManagerCarry managerCarry = interactorTransform.GetComponent<ManagerCarry>();
        
        if (managerCarry != null && !managerCarry.isHandFull)
        {
            if (currentTask == EmployeeTask.Mail){
                managerCarry.PickUpItem("Post", mail, CarrySlot.Hand);
                DayStats.instance.IncreaseMailCount();
                currentTask = EmployeeTask.None;
                computer.sprite = noTask;
                needsHelp = false;
            }
        }

        if (managerCarry != null && managerCarry.currentHandItem =="Coffee" && coffeeCount < 3)
        {
            // burda bişi daha olacak
            coffeeCount += 1;
            managerCarry.DropItem(CarrySlot.Hand);
            if (coffeeCount >= 3)
            {
                Debug.Log("Çarpıntı!!!");
            }
        }
    }

    public void Update()
    {
        
        anim.SetFloat("Speed", aiPath.velocity.magnitude);
        sr.flipX = aiPath.velocity.x < 0;

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
        
        if (needsHelp && !anim.GetBool("Waiting"))
        {
            sleepCooldown -= Time.deltaTime;
            if (sleepCooldown <= 0f)
            {
                DayStats.instance.EmployeesSleepingCounter();
                sleepCooldown = 1f;
            }
        }
        else { sleepCooldown = 0f; }

        if (needsHelp && anim.GetBool("Waiting"))
        {
            angerCooldown -= Time.deltaTime;
            if (angerCooldown <= 0f)
            {
                DayStats.instance.IncreaseEmployeeAngerSeconds();
                angerCooldown = 1f;
            }
        }
        else { angerCooldown = 0f; }
        
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