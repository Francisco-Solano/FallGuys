using UnityEngine;

public class PalaScript : MonoBehaviour
{
    public float rotationSpeed = 5f; // Velocidad de rotaci�n ajustable

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener la direcci�n de la colisi�n
            Vector3 collisionDirection = collision.contacts[0].point - transform.position;
            collisionDirection.Normalize();

            // Calcular el �ngulo de rotaci�n basado en la direcci�n de la colisi�n
            float rotationAngle = Vector3.Dot(collisionDirection, transform.forward) > 0 ? 1 : -1;

            // Rotar el objeto alrededor del eje Y
            RotateDoor(rotationAngle * rotationSpeed);
        }
    }

    void RotateDoor(float angle)
    {
        // Obtener la rotaci�n actual del objeto
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Calcular la nueva rotaci�n alrededor del eje Y
        float newRotationY = currentRotation.y + angle;

        // Aplicar la rotaci�n al objeto
        transform.rotation = Quaternion.Euler(new Vector3(currentRotation.x, newRotationY, currentRotation.z));
    }
}