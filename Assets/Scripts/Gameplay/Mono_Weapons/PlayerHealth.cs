using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Salud m�xima del jugador
    private int currentHealth;   // Salud actual del jugador

    public GameObject deathEffect;  // Efecto visual o animaci�n al morir
    public bool isDead = false;    // Estado de muerte del jugador

    private void Start()
    {
        currentHealth = maxHealth;  // Inicializar la salud del jugador con el m�ximo valor
    }

    // M�todo para recibir da�o
    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Si el jugador ya est� muerto, no recibir da�o

        currentHealth -= damage;  // Reducir la salud actual por el da�o recibido
        Debug.Log("Jugador recibi� " + damage + " de da�o. Salud restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();  // Llamar al m�todo de muerte si la salud llega a 0 o menos
        }
    }

    // M�todo para manejar la muerte del jugador
   
   private void Die()
   {
            Debug.Log("El jugador ha muerto!");
            // Aqu� reiniciamos el nivel cuando el jugador muere
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
   }
   

    // Detecta la colisi�n con las balas del enemigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))  // Si la bala tiene el tag "EnemyBullet"
        {
            EnemyBullet bullet = other.GetComponent<EnemyBullet>();  // Obtener el script de la bala del enemigo
            if (bullet != null)
            {
                TakeDamage(bullet.damage);  // Aplicar da�o al jugador
            }

            Destroy(other.gameObject);  // Destruir la bala despu�s de colisionar
        }
    }
}
