using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrashBin : MonoBehaviour, IInteractable
{
    public InteractGroup Group => InteractGroup.Work;
    private SpriteRenderer sr;

    private Color originalColor;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        
    }
    public void Interact(Transform interactorTransform)
    {
        ManagerCarry manager = interactorTransform.GetComponent<ManagerCarry>();
        if(manager != null && manager.isHandFull)
        {
            if( manager.currentHandItem == "Coffee" || manager.currentHandItem == "Ink")
            {
                manager.DropItem(CarrySlot.Hand);
                Debug.Log("dropped");
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
