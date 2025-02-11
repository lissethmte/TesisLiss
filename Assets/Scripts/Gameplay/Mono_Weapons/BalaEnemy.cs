using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifetime = 5f; // Tiempo antes de que la bala se destruya
    public int damage = 1; // Da�o que inflige la bala
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        // Destruir la bala autom�ticamente despu�s de un tiempo
        Destroy(gameObject, lifetime);

        // Mover la bala hacia adelante usando Rigidbody
        rb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar si la colisi�n fue con el jugador
        if (other.CompareTag("Player"))
        {
            // Intentar obtener el script de salud del jugador
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Aplicar da�o al jugador
            }

            // Destruir la bala despu�s de colisionar
            Destroy(gameObject);
        }
    }
}
