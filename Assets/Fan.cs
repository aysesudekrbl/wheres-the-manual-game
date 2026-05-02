using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Fan : MonoBehaviour,IInteractable
{
    private SpriteRenderer sr;
    private Color originalColor;
    public Sprite fan;

    public InteractGroup Group => InteractGroup.Work;


    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
    public void Interact(Transform interactorTransform)
    {
        ManagerCarry manager = interactorTransform.GetComponent<ManagerCarry>();

        if (!manager.isHeadFull){
            manager.PickUpItem("Fan",fan,CarrySlot.Head);
            sr.enabled = false;
        }
        else
        {
            if(manager.currentHeadtem == "Fan"){
                sr.enabled = true;
                manager.DropItem(CarrySlot.Head);
            }
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