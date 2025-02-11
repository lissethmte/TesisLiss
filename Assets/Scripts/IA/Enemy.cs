using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima del enemigo
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Inicializar salud al máximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir salud
        Debug.Log("Enemigo recibió " + damage + " de daño. Salud restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Llamar a método de muerte si la salud llega a 0
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto tiene el tag "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Buscar el script "Bali" en el objeto que colisionó
            Bali bullet = other.GetComponent<Bali>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage); // Aplicar el daño de la bala
            }

            // Destruir la bala después de impactar
            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        Debug.Log("Enemigo ha muerto!");
        Destroy(gameObject); // Destruir el enemigo
    }
}
