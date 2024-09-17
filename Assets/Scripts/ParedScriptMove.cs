using UnityEngine;

public class ParedScriptMove : MonoBehaviour
{
    public float longitudMaxima = 10f; // Longitud m�xima que puedes indicar
    public float velocidad = 2f; // Velocidad de movimiento

    private float desplazamientoInicial;

    void Start()
    {
        // Guarda la posici�n inicial en el eje x
        desplazamientoInicial = transform.position.x;
    }

    void Update()
    {
        // Calcula el desplazamiento en funci�n del tiempo y la velocidad,
        // sumando el desplazamiento inicial
        float desplazamiento = desplazamientoInicial + Mathf.PingPong(Time.time * velocidad, longitudMaxima * 2) - longitudMaxima;

        // Actualiza la posici�n del objeto en el eje x
        transform.position = new Vector3(desplazamiento, transform.position.y, transform.position.z);
    }
}
