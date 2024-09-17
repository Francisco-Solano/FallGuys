using UnityEngine;

public class Maza_Move : MonoBehaviour
{
    public float amplitud = 45f; // Amplitud del movimiento pendular
    public float velocidad = 2f; // Velocidad de oscilaci�n

    private Vector3 initialRotation;

    private void Start()
    {
        // Almacena la rotaci�n inicial del GameObject
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        // Calcula el �ngulo de rotaci�n usando la funci�n sinusoidal para el movimiento pendular
        float anguloRotacion = amplitud * Mathf.Sin(velocidad * Time.time);

        // Aplica la rotaci�n al GameObject
        transform.rotation = Quaternion.Euler(initialRotation.x + anguloRotacion, initialRotation.y, initialRotation.z);
    }
}
