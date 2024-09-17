using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public float tiempoMaximoEnMinutos = 5f;
    private float tiempoRestante;
    private bool finJuego = false;

    public TextMeshProUGUI timerText;
    public ContadorVidas contadorVidas; // Agrega esta referencia

    void Start()
    {
        tiempoRestante = tiempoMaximoEnMinutos * 60f; // Convertir minutos a segundos
        UpdateTimerText();
    }

    void Update()
    {
        if (!finJuego)
        {
            tiempoRestante -= Time.deltaTime;
            UpdateTimerText();

            if (tiempoRestante <= 0)
            {
                finJuego = true;
                contadorVidas.PerderVida(); // Llama al método PerderVida del contador de vidas
                RestartLevel();
                EndGame("Se acabó el tiempo, vuelve a intentarlo");
            }
        }
    }

    void EndGame(string message)
    {
        Debug.Log(message);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
            int segundos = Mathf.FloorToInt(tiempoRestante % 60f);

            timerText.text = string.Format("Tiempo Restante: {0:00}:{1:00}", minutos, segundos);
        }
    }
}