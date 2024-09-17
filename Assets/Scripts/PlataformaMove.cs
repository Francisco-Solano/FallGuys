using UnityEngine;

public class PlataformaMove : MonoBehaviour
{
    public float longitudMax = 10f; // Longitud máxima que puedes indicar
    public float v = 2f; // Velocidad de movimiento

    private float desplazamientoIn;

    void Start()
    {
        // Guarda la posición inicial en el eje y
        desplazamientoIn = transform.position.y;
    }

    void Update()
    {
        // Calcula el desplazamiento en función del tiempo y la velocidad,
        // sumando el desplazamiento inicial
        float desplazamiento = desplazamientoIn + Mathf.PingPong(Time.time * v, longitudMax * 2) - longitudMax;

        // Actualiza la posición del objeto en el eje y
        transform.position = new Vector3(transform.position.x, desplazamiento, transform.position.z);
    }
}
