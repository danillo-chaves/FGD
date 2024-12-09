using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public float moveSpeed = 3f; 
    private float horizontalInput;
    public Transform heroiT;

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

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetTrigger("pular"); // Ativa a animação de pulo
        }

        // Atualiza a animação de movimento
        if (Mathf.Abs(horizontalInput) > 0)
        {
            animator.SetInteger("estado", 1); // Estado movendo
        }
        else
        {
            animator.SetInteger("estado", 0); // Estado parado
        }

        // Inverte o personagem dependendo da direção
        if (horizontalInput > 0 && heroiT.localScale.x < 0 || horizontalInput < 0 && heroiT.localScale.x > 0)
        {
            Flip();
        }

        // Ataque
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("ataque1"); // Ativa a animação de ataque
        }
    }

    void Flip()
    {
        Vector3 scala = heroiT.localScale;
        scala.x *= -1;
        heroiT.localScale = scala;
    }
}
