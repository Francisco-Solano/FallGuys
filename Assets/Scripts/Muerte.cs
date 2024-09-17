using UnityEngine;
using UnityEngine.SceneManagement;

public class Muerte : MonoBehaviour
{
    private bool gameEnded = false;
    public ContadorVidas contadorVidas;

    void OnTriggerEnter(Collider Col)
    {
        if (Col.CompareTag("Player") && !gameEnded)
        {
            gameEnded = true;
            contadorVidas.PerderVida(); // Llama al método PerderVida del contador de vidas

            if (contadorVidas.TieneVidas())
            {
                // Si todavía tiene vidas, reinicia el nivel
                RestartLevel("Inténtalo de nuevo");
            }
            else
            {
                // Si no tiene vidas, muestra el mensaje de "Has perdido" y reinicia las vidas
                Debug.Log("Has perdido todas las vidas. Reiniciando...");
                contadorVidas.InicializarVidas();
                gameEnded = false; // Restablece el estado del juego para futuras muertes
            }
        }
    }

    void RestartLevel(string message)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(message);
    }
}
