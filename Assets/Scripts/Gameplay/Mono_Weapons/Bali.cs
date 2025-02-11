using UnityEngine;

public class Bali : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifetime = 5f; // Tiempo antes de que la bala se destruya
    public int damage = 5; // Da�o que inflige la bala
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
        // Verificar si el objeto tiene el tag "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Intentar obtener el script "Enemy"
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Aplicar da�o
            }
        }

        // Destruir la bala despu�s de colisionar
        Destroy(gameObject);
    }
}
