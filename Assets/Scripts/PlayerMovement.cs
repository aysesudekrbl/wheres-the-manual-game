using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        if (moveHorizontal != 0)
        {
            Vector2 scale = transform.localScale;
            scale.x = moveHorizontal > 0 ? 1: -1;

            transform.localScale = scale;
 
        }
        rb.velocity = new Vector2(moveHorizontal,moveVertical) * moveSpeed;


        if (moveHorizontal != 0 || moveVertical != 0)
        {
            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }
    
}
}