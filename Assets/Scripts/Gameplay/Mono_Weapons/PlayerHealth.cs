using UnityEngine;
using TMPro; // Importa TextMeshPro

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100; // Salud máxima
    private int currentHealth;   // Salud actual
    public bool isDead = false;  // Si el jugador está muerto

    public int enemyDamage = 10; // Daño que el jugador recibe de los enemigos
    public float damageInterval = 1f; // Tiempo entre cada daño recibido
    private float nextDamageTime = 0f;

    public TMP_Text healthText; // Referencia al texto de TextMeshPro para la salud

    private void Start()
    {
        currentHealth = maxHealth; // Inicializar la salud
        UpdateHealthUI(); // Actualizar la UI de la salud
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return; // Si el jugador está muerto, no recibe más daño

        currentHealth -= damage; // Reducir la salud
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Asegurarse que no sea negativa

        UpdateHealthUI(); // Actualiza el texto de la salud

        if (currentHealth <= 0)
        {
            Die(); // Si la salud llega a 0, el jugador muere
        }
    }

    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            // Actualiza el texto para mostrar la salud actual sobre la máxima
            healthText.text = "Health: " + currentHealth;
        }
    }

    private void Die()
    {
        Debug.Log("El jugador ha muerto!");
        isDead = true;
        GameManager.instance.GameOver(); // Llamar a Game Over
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (Time.time >= nextDamageTime)
            {
                TakeDamage(enemyDamage);
                nextDamageTime = Time.time + damageInterval; // Control del intervalo de daño
            }
        }
    }
}
