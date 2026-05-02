using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerPhone : MonoBehaviour,IInteractable
{
    private SpriteRenderer sr;
    private Color originalColor;

    public Sprite ringing;
    public Sprite notRinging;
    public bool ManagerPhoneRinging = false;
    public InteractGroup Group => InteractGroup.Work;


    public void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }
    public void Interact(Transform interactorTransform)
    {
        if (ManagerPhoneRinging)
        {
            sr.sprite = notRinging;
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