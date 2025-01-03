using UnityEngine;

public class inimigo : MonoBehaviour
{
    public float moveSpeed = 3f; // Velocidade de perseguição
    public float detectionRange = 5f; // Raio de detecção
    public float attackRange = 1.5f; // Distância para ataque
    public float attackCooldown = 2f; // Tempo entre ataques

    private Transform heroi; // Referência ao jogador
    private float lastAttackTime; // Último tempo de ataque

    private void Start()
    {
        // Encontra o jogador pelo nome "heroi"
        GameObject playerObject = GameObject.Find("heroi");
        if (playerObject != null)
        {
            heroi = playerObject.transform;
        }
        else
        {
            Debug.LogError("Jogador chamado 'heroi' não foi encontrado!");
        }
    }

    private void Update()
    {
        if (heroi == null) return; // Evita erros caso o jogador não tenha sido encontrado

        // Calcula a distância até o jogador
        float distanceToPlayer = Vector2.Distance(transform.position, heroi.position);

        if (distanceToPlayer < detectionRange && distanceToPlayer > attackRange)
        {
            // Persegue o jogador
            ChasePlayer();
        }
        else if (distanceToPlayer <= attackRange && Time.time > lastAttackTime + attackCooldown)
        {
            // Ataca o jogador
            AttackPlayer();
        }
    }

    private void ChasePlayer()
    {
        // Move-se em direção ao jogador
        transform.position = Vector2.MoveTowards(transform.position, heroi.position, moveSpeed * Time.deltaTime);

        // Inverte o inimigo para olhar na direção do jogador
        if (heroi.position.x < transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1); // Olha para a esquerda
        else
            transform.localScale = new Vector3(1, 1, 1); // Olha para a direita
    }

    private void AttackPlayer()
    {
        Debug.Log("Inimigo atacando o heroi!");
        lastAttackTime = Time.time; // Atualiza o tempo do último ataque

        // Aqui você pode adicionar lógica de ataque, como redução de vida do jogador
    }
}
