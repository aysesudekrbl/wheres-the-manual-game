using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterController : MonoBehaviour, IInteractable,IWorkStation
{
    public float inkTime = 15f;
    private float waitTime;
    public bool outOfInk = false;
    
    public Sprite outofInkSprite; 
    public Sprite inkFullSprite;
    private SpriteRenderer sr;
    
    public InteractGroup Group => InteractGroup.Work;

    public bool IsBroken => outOfInk;

    public float WorkDuration => Random.Range(3f,8f);
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SetInkTimer();
    }

    void Update()
    {
        waitTime -= Time.deltaTime; 
    }

    public void OnEmployeeFinished()
    {
        if(waitTime < 0 && !outOfInk)
        {
            NeedsInk();
        }
    }

    public void NotNeedingInk()
    {
        outOfInk = false;
        sr.sprite = inkFullSprite;
        SetInkTimer();
    }

    public void NeedsInk()
    {
        outOfInk = true;
        sr.sprite = outofInkSprite;
    }
    
    public void SetInkTimer()
    {
        waitTime = Random.Range(10f, 40f); 
    }

    public void Interact(Transform interactorTransform)
    {
        ManagerCarry managerCarry = interactorTransform.GetComponent<ManagerCarry>();
        
        if (managerCarry != null && managerCarry.isHandFull && outOfInk)
        {
            if (managerCarry.currentHandItem == "Ink"){
                managerCarry.DropItem(CarrySlot.Hand);
                
                NotNeedingInk();
            }
        }

    }

    public void onTouchingPlayer() { sr.color = Color.red; }
    public void onNotTouchingPlayer() { sr.color = Color.white; } // Veya originalColor
}