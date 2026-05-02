using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BirdCage : MonoBehaviour, IInteractable
{
    public InteractGroup Group => InteractGroup.Work;
    private SpriteRenderer sr;

    private Color originalColor;
    public Sprite bird;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
    public void Interact(Transform interactorTransform)
    {
        ManagerCarry managerCarry = interactorTransform.GetComponent<ManagerCarry>();
        if (managerCarry != null && !managerCarry.isHeadFull)
        {
            managerCarry.PickUpItem("Bird", bird, CarrySlot.Head);
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
