using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour,IInteractable

{
    public InteractGroup Group => InteractGroup.Environment;
    private SpriteRenderer sr;
    private Color originalColor;
    private bool isOpen = false;
    public Sprite windowOpen;
    public Sprite windowClosed;


    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
    public void Interact(Transform interactorTransform)
    {
        ManagerCarry manager = interactorTransform.GetComponent<ManagerCarry>();
        if (isOpen)
        {
            if (manager.isHeadFull && manager.isHandFull)
            {
                if(manager.currentHandItem == "Post" && manager.currentHeadtem == "Bird")
                {
                    manager.DropItem(CarrySlot.Hand);
                    manager.DropItem(CarrySlot.Head);
                }

            }

            else{
                    sr.sprite = windowClosed;
                    isOpen = false;
                }
        }

        else
        {
            sr.sprite = windowOpen;
            isOpen = true;
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