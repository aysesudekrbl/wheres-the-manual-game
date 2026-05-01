using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Employee : MonoBehaviour,IInteractable
{
    private SpriteRenderer sr;
    private Color originalColor;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    public void Interact(Transform interactorTransform)
    {
        Destroy(gameObject);
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