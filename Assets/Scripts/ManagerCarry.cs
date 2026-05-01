using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarrySlot
{
    Hand,
    Head
}
public class ManagerCarry : MonoBehaviour
{
   [Header("Hand Bölmesi")]
   public SpriteRenderer handDisplay;
   public bool isHandFull = false;
   public string currentHandItem = "";

   [Header("Head Bölmesi")]
   public SpriteRenderer headDisplay;
   public bool isHeadFull = false;
   public string currentHeadtem = "";


public void PickUpItem(string itemName, Sprite itemSprite, CarrySlot slot)
    {
        if(slot == CarrySlot.Hand && !isHandFull)
        {
            isHandFull = true;
            currentHandItem = itemName;
            handDisplay.sprite = itemSprite;
            handDisplay.sortingOrder = 3;
            handDisplay.enabled = true;
        }

        else if (slot == CarrySlot.Head && !isHeadFull)
        {
            isHeadFull = true;
            currentHeadtem = itemName;
            headDisplay.sprite = itemSprite;
            headDisplay.sortingOrder = 3;
            headDisplay.enabled = true;
        }
}

        public void DropItem(CarrySlot slot)
    {
        if (slot == CarrySlot.Hand)
        {
            isHandFull = false;
            currentHandItem = "";
            handDisplay.sprite = null;
            handDisplay.enabled = false;
        }

        if(slot == CarrySlot.Head)
        {
            isHeadFull = false;
            currentHeadtem = "";
            headDisplay.sprite = null;
            headDisplay.enabled = false;
        }
    }
    }
