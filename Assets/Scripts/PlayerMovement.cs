using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D rb;

    private bool upKeyAction;
    private bool downKeyAction;

    public float speed;
    public float jump;
    public float swimMovementAmount;
    public Animator animator;
    public bool isJumping;
    public bool isOnIdleState;

    // TODO: preguntar al profe si es mejor un flag o simplemente hacer la
    // verificacion de la escena con el SceneManager
    public bool isUnderWaterScene;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        upKeyAction = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow);
        downKeyAction = Input.GetKeyDown(KeyCode.DownArrow);
        if (!isUnderWaterScene)
        {
            runnerMechanics();
        }
        else
        {
            swimmingMechanics();
        }
    }

    private void swimmingMechanics()
    {
        // TODO: mejorar la acción de nadar hacia arriba porque no se ve
        // natural.
        rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
        rb.gravityScale = 0f;
        animator.SetBool("isSwimming", true);
        if (upKeyAction)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, swimMovementAmount);
        }
        else if (downKeyAction)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, -swimMovementAmount);
        }
    }

    private void runnerMechanics()
    {
        rb.gravityScale = 1f;
        if (!isOnIdleState)
        {
            // correr cuando no estoy en idle
            animator.SetBool("isInLobby", false);
            rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
        }
        if (isJumping)
        {
            // Animacion de cayendo en la escena de cave.
            animator.SetBool("isJumping", true);
        }
        if (upKeyAction && !isJumping)
        {
            if (isOnIdleState)
            {
                // Comenzar el juego con la accion de saltar
                isOnIdleState = false;
                animator.SetBool("isInLobby", false);
            }
            else
            {
                // Simple salto, boring
                rb.AddForce(new Vector2(rb.linearVelocityX, jump));
            }
        }
    }

    // -------------------------------------------------
    // override functions
    // mecanica de salto con un simple ground check
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

