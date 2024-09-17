using UnityEngine;

public class GiroPivote : MonoBehaviour
{
    public float velocidadRotacion = 30f; // Velocidad de rotaci�n en grados por segundo
    public float tiempoMinimoCambioDireccion = 3f; // Tiempo m�nimo en segundos antes de cambiar de direcci�n

    private float tiempoParaCambioDireccion;

    void Start()
    {
        // Inicializa el tiempo para el primer cambio de direcci�n
        tiempoParaCambioDireccion = Random.Range(tiempoMinimoCambioDireccion, tiempoMinimoCambioDireccion * 2);
    }

    void Update()
    {
        // Gira el objeto alrededor del eje Y
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);

        // Actualiza el tiempo para el cambio de direcci�n
        tiempoParaCambioDireccion -= Time.deltaTime;

        // Si ha pasado el tiempo m�nimo para el cambio de direcci�n
        if (tiempoParaCambioDireccion <= 0f)
        {
            // Cambia la direcci�n de giro
            velocidadRotacion *= -1f;

            // Establece un nuevo tiempo para el pr�ximo cambio de direcci�n
            tiempoParaCambioDireccion = Random.Range(tiempoMinimoCambioDireccion, tiempoMinimoCambioDireccion * 2);
        }
    }
}
