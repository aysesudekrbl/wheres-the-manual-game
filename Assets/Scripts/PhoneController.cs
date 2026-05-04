using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public float ringingTime = 5f;
    private float waitTime;
    public bool isRinging = false;
    public Sprite ringing;
    public Sprite notRinging;
    private SpriteRenderer sr;
    
    void Start()
    {
        SetPhoneTimer();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       waitTime -= Time.deltaTime;
       if(waitTime < 0 && !isRinging)
        {
            PhoneRinging();
        }
        if (waitTime < 0 && isRinging)
        {
            DidntPickUp();
        }

    }

    public void PhoneRinging()
    {
        isRinging = true;
        waitTime = ringingTime;
        sr.sprite = ringing;

    }

    public void DidntPickUp()
    {
        isRinging = false;
        SetPhoneTimer();
        Debug.Log("Patron geldi");
        sr.sprite = notRinging;
    }

    public void Pickup()
    {
        isRinging = false;
        SetPhoneTimer();
        Debug.Log("Zamanında açıldı");
        sr.sprite = notRinging;
    }

    public void SetPhoneTimer()
    {
        waitTime = Random.Range(1f,4f);
    }
}


