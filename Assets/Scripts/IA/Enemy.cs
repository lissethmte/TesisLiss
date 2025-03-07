using UnityEngine;
using UnityEngine.VFX;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public VisualEffect efectoDano;
    public GameObject objetoVFX;
    public float duracionVFX = 1f;

    // Nuevo VFX
    public VisualEffect efectoDano2;
    public GameObject objetoVFXDano2;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Enemigo recibió " + damage + " de daño. Salud restante: " + currentHealth);

        if (efectoDano != null && objetoVFX != null)
        {
            objetoVFX.SetActive(true);
            efectoDano.Play();
            Invoke("DetenerVFX", duracionVFX);
        }

        // Activa el segundo VFX
        if (efectoDano2 != null && objetoVFXDano2 != null)
        {
            objetoVFXDano2.SetActive(true);
            efectoDano2.Play();
            Invoke("DetenerVFX2", duracionVFX); // Utiliza la misma duración
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Bali bullet = other.GetComponent<Bali>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }

            Destroy(other.gameObject);
        }
    }

    private void Die()
    {
        Debug.Log("Enemigo ha muerto!");
        Destroy(gameObject);
    }

    private void DetenerVFX()
    {
        if (efectoDano != null && objetoVFX != null)
        {
            efectoDano.Stop();
            objetoVFX.SetActive(false);
        }
    }

    private void DetenerVFX2()
    {
        if (efectoDano2 != null && objetoVFXDano2 != null)
        {
            efectoDano2.Stop();
            objetoVFXDano2.SetActive(false);
        }
    }
}