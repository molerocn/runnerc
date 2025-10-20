using UnityEngine;
using UnityEngine.SceneManagement;

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

    private float timer = 0f;

    private bool isUnderWaterScene;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isUnderWaterScene = SceneManager.GetActiveScene().name == "UnderWater";
        upKeyAction = Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.UpArrow);
        downKeyAction = Input.GetKeyDown(KeyCode.DownArrow);
        if (!isOnIdleState)
        {
            timer += Time.deltaTime;

            if (timer >= 0.5f)
            {
                GameManager.Instance.AddScore(1);
                timer = 0f;
            }
        }
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
        // statement unicamente para la animacion de cayendo en la escena de cave.
        if (isJumping)
        {
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
                isJumping = true;
                animator.SetBool("isJumping", true);
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
            ContactPoint2D contact = collision.contacts[0];

        // 3. Calcula la dirección de la normal de la colisión.
        // La normal es un vector perpendicular a la superficie de contacto.
        // Si el jugador aterriza en una superficie plana, la normal apunta hacia arriba (cercana a Vector2.up o (0, 1)).
        
        // Un valor de y = 0.9f o más es una buena señal de que es un aterrizaje plano.
        float surfaceNormalY = contact.normal.y;

        // 4. Lógica de Aterrizaje (El Player viene de arriba)
        if (surfaceNormalY > 0.9f) // Cerca de 1.0 (Vector2.up)
        {
            // El jugador está aterrizando desde arriba (o desde un lado plano).
            
            // RESETEAR LA FUERZA:
            // Anula la velocidad vertical para detener el impulso y evitar acumulación.
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

            // Restablecer flags
            isJumping = false;
            animator.SetBool("isJumping", false);
        }
        }
    }
}

