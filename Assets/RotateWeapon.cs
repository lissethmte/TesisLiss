using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public float rotationSpeed = 10f;  // Velocidad de rotación

    private void Update()
    {
        // Rotación continua sobre el eje Y (puedes cambiar el eje de rotación si lo deseas)
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
