using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public Animator animator;

    private Rigidbody2D rb;
    public bool isJumping;
    private bool isInLobby = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isInLobby)
        {
            rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
        }
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            if (isInLobby)
            {
                isInLobby = false;
                animator.SetBool("isInLobby", false);
            }
            else
            {
                rb.AddForce(new Vector2(rb.linearVelocityX, jump));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
            animator.SetBool("isJumping", true);
        }
    }
}

