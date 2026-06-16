using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMachine : MonoBehaviour,IInteractable
{

    public Sprite coffee;
    private SpriteRenderer sr;
    private Color originalColor;
    public InteractGroup Group => InteractGroup.Environment;

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
            managerCarry.PickUpItem("Coffee", coffee, CarrySlot.Hand);
            DayStats.instance.IncreaseCoffeeCount();
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