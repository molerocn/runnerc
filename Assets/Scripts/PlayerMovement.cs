using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;

    private Rigidbody2D rb;
    public bool isJumping;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(rb.linearVelocityX, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }
}

