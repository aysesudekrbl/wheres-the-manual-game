using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Employee : MonoBehaviour,IInteractable
{
    public InteractGroup Group => InteractGroup.Work;
    private SpriteRenderer sr;
    private Color originalColor;

    public Sprite mail;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void Interact(Transform interactorTransform)
    {
        ManagerCarry managerCarry = interactorTransform.GetComponent<ManagerCarry>();
        
        if (managerCarry != null && !managerCarry.isHandFull)
        {
            
            managerCarry.PickUpItem("Post", mail, CarrySlot.Hand);
        }
    }

    public void onNotTouchingPlayer()
    {
        sr.color = originalColor;
    }

    public void onTouchingPlayer()
    {
        sr.color = Color.red;
    }

}