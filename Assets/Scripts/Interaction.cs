using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IInteractable{
    InteractGroup Group { get; }

    void Interact(Transform interactorTransform);
    void onTouchingPlayer();
    void onNotTouchingPlayer();

}

public enum InteractGroup{
    Environment,
    Work
}
public class Interaction : MonoBehaviour
{
    
    private IInteractable currentInteractable;
    void Update()
    {
       if (currentInteractable != null){
            if(Input.GetButtonDown("Jump"))
            {
                if (currentInteractable.Group == InteractGroup.Work){
                    currentInteractable.Interact(transform);
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (currentInteractable.Group == InteractGroup.Environment){
                    currentInteractable.Interact(transform);
                }
            }
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

