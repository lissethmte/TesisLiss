using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifetime = 5f; // Tiempo antes de que la bala se destruya
    public int damage = 1; // Daño que inflige la bala
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Destruir la bala automáticamente después de un tiempo
        Destroy(gameObject, lifetime);

        // Mover la bala hacia adelante usando Rigidbody
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisión fue con el jugador
        if (other.CompareTag("Player"))
        {
            // Intentar obtener el script de salud del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Aplicar daño al jugador
            }

            // Destruir la bala después de colisionar
            Destroy(gameObject);
        }
    }
}
