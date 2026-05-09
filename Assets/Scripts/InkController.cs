using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterController : MonoBehaviour, IInteractable
{
    public float inkTime = 15f;
    private float waitTime;
    public bool outOfInk = false;
    
    public Sprite outofInkSprite; 
    public Sprite inkFullSprite;
    private SpriteRenderer sr;
    
    public InteractGroup Group => InteractGroup.Work;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        SetInkTimer();
    }

    void Update()
    {
        waitTime -= Time.deltaTime; 
    }

    public void OnEmployeeFinished()
    {
        if(waitTime < 0 && !outOfInk)
        {
            NeedsInk();
        }
    }

    public void NotNeedingInk()
    {
        outOfInk = false;
        sr.sprite = inkFullSprite;
        SetInkTimer();
    }

    public void NeedsInk()
    {
        outOfInk = true;
        sr.sprite = outofInkSprite;
    }
    
    public void SetInkTimer()
    {
        waitTime = Random.Range(3f, 8f); 
    }

    public void Interact(Transform interactorTransform)
    {
        if (outOfInk) NotNeedingInk();
    }

    public void onTouchingPlayer() { sr.color = Color.red; }
    public void onNotTouchingPlayer() { sr.color = Color.white; } // Veya originalColor
}