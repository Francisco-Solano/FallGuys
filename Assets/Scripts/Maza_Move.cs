using UnityEngine;

public class Maza_Move : MonoBehaviour
{
    public float amplitud = 45f; // Amplitud del movimiento pendular
    public float velocidad = 2f; // Velocidad de oscilación

    private Vector3 initialRotation;

    private void Start()
    {
        // Almacena la rotación inicial del GameObject
        initialRotation = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        // Calcula el ángulo de rotación usando la función sinusoidal para el movimiento pendular
        float anguloRotacion = amplitud * Mathf.Sin(velocidad * Time.time);

        // Aplica la rotación al GameObject
        transform.rotation = Quaternion.Euler(initialRotation.x + anguloRotacion, initialRotation.y, initialRotation.z);
    }
}
