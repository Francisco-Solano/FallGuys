using UnityEngine;

public class GiroTambor : MonoBehaviour
{
    public float velocidadRotacion = 30f; // Velocidad de rotación en grados por segundo

    void Update()
    {
        // Gira el objeto alrededor del eje Y
        transform.Rotate(Vector3.up, velocidadRotacion * Time.deltaTime);
    }
}
