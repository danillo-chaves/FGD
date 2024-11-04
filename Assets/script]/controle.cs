using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public float moveSpeed = 3f; 
    private bool isGrounded;
    private float horizontalInput;
    public Transform heroiT;
    public bool podepular = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Movimento horizontal
        horizontalInput = Input.GetAxis("Horizontal"); // -1 para esquerda, 1 para direita
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Atualiza a animação de movimento
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        // Inverte o personagem dependendo da direção
        if (horizontalInput > 0 && heroiT.localScale.x < 0 || horizontalInput < 0 && heroiT.localScale.x > 0)
        {
            Flip();
        }
        
        // Atualiza o parâmetro "AirSpeed" no Animator com a velocidade vertical
        animator.SetFloat("AirSpeedY", rb.velocity.y);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space) && podepular)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("Jump"); // Ativa a animação de pulo
        }

        // Ataque
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack1"); // Ativa a animação de ataque
        }
    }

    void Flip()
    {
        Vector3 scala = heroiT.localScale;
        scala.x *= -1;
        heroiT.localScale = scala;
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            podepular = true;
            animator.SetBool("Grounded", true);
        }
    }

    void OnCollisionExit2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("chao"))
        {
            podepular = false;
            animator.SetBool("Grounded", false);
        }
    }
}
