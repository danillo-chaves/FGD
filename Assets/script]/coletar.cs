using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectCoins : MonoBehaviour
{
    private int coinCount = 0;  // Contador de moedas coletadas

    // Método que é chamado quando o personagem entra em um Trigger (moeda)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica se o objeto com o qual colidiu tem a tag "Moeda"
        if (collision.gameObject.CompareTag("Moeda"))
        {
            // Aumenta o contador de moedas
            coinCount++;
            Debug.Log("Moedas coletadas: " + coinCount);

            // Destroi o objeto (moeda)
            Destroy(collision.gameObject);
        }
    }
}
