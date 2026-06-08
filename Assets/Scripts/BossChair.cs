using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossChair : MonoBehaviour,IInteractable,IWorkStation
{

    public InteractGroup Group => InteractGroup.Environment;

    public bool IsBroken => !sitting;

    public float WorkDuration => Random.Range(3f,8f);

    private Vector2 originalPlayerPosition;
    private bool sitting = false;
    private SpriteRenderer sr;
    private Color originalColor;
    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        
    }
    public void Interact(Transform interactorTransform)
    {
    
        if(interactorTransform.GetComponent<PlayerMovement>() != null)
            {
                if (!sitting){
                    Rigidbody2D rb = interactorTransform.GetComponent<Rigidbody2D>();
                        if (rb != null)
                        {
                            rb.linearVelocity = Vector2.zero;
                        }

                    Animator anim = interactorTransform.GetComponent<Animator>();
                        if (anim != null)
                        {
                            anim.SetBool("isRunning", false);
                        }

                    originalPlayerPosition = interactorTransform.position;
                    interactorTransform.GetComponent<PlayerMovement>().enabled = false;
                    interactorTransform.position = transform.position;
                    sitting = true;
             }
            
            else
            {
                interactorTransform.GetComponent<PlayerMovement>().enabled = true;
                interactorTransform.position = originalPlayerPosition;
                sitting = false;
            }
            }

        
    }

    public void onNotTouchingPlayer()
    {
        sr.color = originalColor;
    }

    public void onTouchingPlayer()
    {
        if (!sitting){
            sr.color = Color.red;
        }

        else
        {
            sr.color = originalColor;
        }
    }

    public void OnEmployeeFinished()
    {
        
    }
}