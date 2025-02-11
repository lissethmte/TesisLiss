using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public float rotationSpeed = 10f;  // Velocidad de rotaci�n

    private void Update()
    {
        // Rotaci�n continua sobre el eje Y (puedes cambiar el eje de rotaci�n si lo deseas)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
