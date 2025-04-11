using UnityEngine;

public class Puntos : MonoBehaviour
{
    public int enemyScore = 10; // Puntos que otorga al morir

    public void Die()
    {
        GameManager.instance.AddScore(enemyScore); // Sumar puntos al jugador
        Destroy(gameObject); // Elimina al enemigo
    }
}

