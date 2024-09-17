using UnityEngine;

public class GiroPivote : MonoBehaviour
{
    public float velocidadRotacion = 30f; // Velocidad de rotación en grados por segundo
    public float tiempoMinimoCambioDireccion = 3f; // Tiempo mínimo en segundos antes de cambiar de dirección

    private float tiempoParaCambioDireccion;

    void Start()
    {
        // Inicializa el tiempo para el primer cambio de dirección
        tiempoParaCambioDireccion = Random.Range(tiempoMinimoCambioDireccion, tiempoMinimoCambioDireccion * 2);
    }

    void Update()
    {
        // Gira el objeto alrededor del eje Y
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);

        // Actualiza el tiempo para el cambio de dirección
        tiempoParaCambioDireccion -= Time.deltaTime;

        // Si ha pasado el tiempo mínimo para el cambio de dirección
        if (tiempoParaCambioDireccion <= 0f)
        {
            // Cambia la dirección de giro
            velocidadRotacion *= -1f;

            // Establece un nuevo tiempo para el próximo cambio de dirección
            tiempoParaCambioDireccion = Random.Range(tiempoMinimoCambioDireccion, tiempoMinimoCambioDireccion * 2);
        }
    }
}
