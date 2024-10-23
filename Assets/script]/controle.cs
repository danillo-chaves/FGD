using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidade de movimento
    public Rigidbody2D rb;  // Referência ao Rigidbody2D do personagem
    private Vector2 movement;  // Armazena a direção do movimento
    public float jumpForce = 101f;  // Força do pulo

    private bool isGrounded;  // Indica se o personagem está no chão
    public Transform groundCheck;  // Referência ao objeto que faz a verificação do chão
    public LayerMask groundLayer;  // Layer que representa o chão

    void Update()
    {
        // Captura a entrada do jogador (teclado) para movimento horizontal
        movement.x = Input.GetAxisRaw("Horizontal");

        // Aplica movimento horizontal
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Verifica se o personagem está no chão (usando sobreposição de colisor)
        isGrounded = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.5f, 0.1f), 0f, groundLayer);

        // Detecta se o botão de pulo (barra de espaço) foi pressionado e se o personagem está no chão
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);  // Aplica o pulo
        }
    }

    // Desenhar o OverlapBox para ajudar a ajustar o tamanho no editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, new Vector2(0.5f, 0.1f));
    }
}
