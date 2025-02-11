using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // Salud m�xima del enemigo
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth; // Inicializar salud al m�ximo
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reducir salud
        Debug.Log("Enemigo recibi� " + damage + " de da�o. Salud restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Llamar a m�todo de muerte si la salud llega a 0
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto tiene el tag "Bullet"
        if (other.CompareTag("Bullet"))
        {
            // Buscar el script "Bali" en el objeto que colision�
            Bali bullet = other.GetComponent<Bali>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage); // Aplicar el da�o de la bala
            }

            // Destruir la bala despu�s de impactar
            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        Debug.Log("Enemigo ha muerto!");
        Destroy(gameObject); // Destruir el enemigo
    }
}
