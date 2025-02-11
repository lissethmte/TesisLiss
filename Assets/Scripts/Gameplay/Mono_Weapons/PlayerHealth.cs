using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;  // Salud máxima del jugador
    private int currentHealth;   // Salud actual del jugador

    public GameObject deathEffect;  // Efecto visual o animación al morir
    public bool isDead = false;    // Estado de muerte del jugador

    private void Start()
    {
        currentHealth = maxHealth;  // Inicializar la salud del jugador con el máximo valor
    }

    // Método para recibir daño
    public void TakeDamage(int damage)
    {
        if (isDead) return;  // Si el jugador ya está muerto, no recibir daño

        currentHealth -= damage;  // Reducir la salud actual por el daño recibido
        Debug.Log("Jugador recibió " + damage + " de daño. Salud restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();  // Llamar al método de muerte si la salud llega a 0 o menos
        }
    }

    // Método para manejar la muerte del jugador
   
   private void Die()
   {
            Debug.Log("El jugador ha muerto!");
            // Aquí reiniciamos el nivel cuando el jugador muere
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena actual
   }
   

    // Detecta la colisión con las balas del enemigo
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))  // Si la bala tiene el tag "EnemyBullet"
        {
            EnemyBullet bullet = other.GetComponent<EnemyBullet>();  // Obtener el script de la bala del enemigo
            if (bullet != null)
            {
                TakeDamage(bullet.damage);  // Aplicar daño al jugador
            }

            Destroy(other.gameObject);  // Destruir la bala después de colisionar
        }
    }
}
