using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable{
    void Interact(Transform interactorTransform);
    void onTouchingPlayer();
    void onNotTouchingPlayer();

}
public class Interaction : MonoBehaviour
{
    private IInteractable currentInteractable;
    void Update()
    {
       
        if(Input.GetButtonDown("Jump") && currentInteractable != null)
        {
            currentInteractable.Interact(transform);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null)
        {
            currentInteractable = interactable;
            currentInteractable.onTouchingPlayer();
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteractable interactable = collision.GetComponent<IInteractable>();
        if (interactable != null && interactable == currentInteractable)
        {
            currentInteractable.onNotTouchingPlayer();
            currentInteractable = null;
        }
        
    }
}

