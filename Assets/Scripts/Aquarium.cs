using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aquarium : MonoBehaviour,IInteractable
{

    public Sprite ink;
    private SpriteRenderer sr;
    private Color originalColor;
    public InteractGroup Group => InteractGroup.Work;

    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void Interact(Transform interactorTransform)
    {
        ManagerCarry managerCarry = interactorTransform.GetComponent<ManagerCarry>();
        
        if (managerCarry != null && !managerCarry.isHandFull)
        {
            managerCarry.PickUpItem("Ink", ink, CarrySlot.Hand);
            DayStats.instance.IncreaseInkCount();
            
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