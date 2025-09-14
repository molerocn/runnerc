using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    public Animator animator;

    private Rigidbody2D rb;
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
        if (isUnderWaterScene)
        {
            // TODO: mejorar la acción de nadar hacia arriba porque no se ve
            // natural.
            rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
            animator.SetBool("isSwimming", true);
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector2(rb.linearVelocityX, jump));
            }
        }
        else
        {
            if (!isOnIdleState)
            {
                /*
                Simplemente correr cuando el evento de idle no esta activo, es decir
                no estoy en la lobby
                */
                animator.SetBool("isInLobby", false);
                rb.linearVelocity = new Vector2(speed, rb.linearVelocityY);
            }
            if (isJumping)
            {
                // Animacion de cayendo en la escena de cave.
                animator.SetBool("isJumping", true);
            }
            if (Input.GetButtonDown("Jump") && !isJumping)
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
    }

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

