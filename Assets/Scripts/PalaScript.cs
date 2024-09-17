using UnityEngine;

public class PalaScript : MonoBehaviour
{
    public float rotationSpeed = 5f; // Velocidad de rotación ajustable

    void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener la dirección de la colisión
            Vector3 collisionDirection = collision.contacts[0].point - transform.position;
            collisionDirection.Normalize();

            // Calcular el ángulo de rotación basado en la dirección de la colisión
            float rotationAngle = Vector3.Dot(collisionDirection, transform.forward) > 0 ? 1 : -1;

            // Rotar el objeto alrededor del eje Y
            RotateDoor(rotationAngle * rotationSpeed);
        }
    }

    void RotateDoor(float angle)
    {
        // Obtener la rotación actual del objeto
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // Calcular la nueva rotación alrededor del eje Y
        float newRotationY = currentRotation.y + angle;

        // Aplicar la rotación al objeto
        transform.rotation = Quaternion.Euler(new Vector3(currentRotation.x, newRotationY, currentRotation.z));
    }
}