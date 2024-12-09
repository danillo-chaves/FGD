using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    public float moveSpeed = 3f; 
    private float horizontalInput;
    public Transform heroiT;
    private int coinCount;
    public TMP_Text textCoins;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        // Movimento horizontal
        horizontalInput = Input.GetAxis("Horizontal"); // -1 para esquerda, 1 para direita
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Pulo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
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
    void OnTriggerEnter2D(Collider2D col)
    {
        // Se o objeto colidido for a moeda
        if (col.CompareTag("moeda"))
        {
            // Aumenta o contador de moedas
            coinCount++;
            textCoins.text = "Moedas coletadas: " + coinCount;
            Debug.Log("Moedas coletadas: " + coinCount);

            // Destroi a moeda
            Destroy(col.gameObject);
        }
        
    }
    

}
