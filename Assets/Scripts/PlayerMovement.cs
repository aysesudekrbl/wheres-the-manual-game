using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Animator animator;
    private Rigidbody2D rb;
    private bool isCounting = false;

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
            scale.x = moveHorizontal > 0 ? 1 : -1;
            transform.localScale = scale;
        }

        rb.linearVelocity = new Vector2(moveHorizontal, moveVertical) * moveSpeed;

        if (moveHorizontal != 0 || moveVertical != 0)
        {
            animator.SetBool("isRunning", true);
            if (!isCounting)
            {
                isCounting = true;
                InvokeRepeating("CountStep", 0.2f, 0.025f);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            if (isCounting)
            {
                isCounting = false;
                CancelInvoke("CountStep");
            }
        }
    }

    void CountStep()
    {
        DayStats.instance.IncreaseStepCount();
    }
}