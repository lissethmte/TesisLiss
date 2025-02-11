using UnityEngine;

public class Bali : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifetime = 5f; // Tiempo antes de que la bala se destruya
    public int damage = 5; // Daño que inflige la bala
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
        // Verificar si el objeto tiene el tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Intentar obtener el script "Enemy"
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Aplicar daño
            }
        }

        // Destruir la bala después de colisionar
        Destroy(gameObject);
    }
}
