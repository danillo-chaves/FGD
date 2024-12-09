using UnityEngine;

public class heroiata : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        // Se o objeto colidido for a inimigo
        if (col.CompareTag("inimigo"))
        {
            // Destroi a inimigo
            Destroy(col.gameObject);
        }
        
    }
}
