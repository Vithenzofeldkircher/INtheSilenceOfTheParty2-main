using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] TMP_Text firstNote;
    [SerializeField] TMP_Text timerText;

    // NOVO: Arraste a sua tela de Game Over/Derrota (um Panel, por exemplo) para cá no Inspector
    public GameObject gameOverScreen;

    public float timerRemaining = 60f;
    public bool timerIsRunning = true;

    void Start()
    {
        // Certifique-se de que a tela de Game Over esteja desativada no início
        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false);
        }
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timerRemaining > 0)
            {
                timerRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timerRemaining);
            }
            else // O tempo acabou!
            {
                timerRemaining = 0;
                timerIsRunning = false;
                UpdateTimerDisplay(0);
                firstNote.gameObject.SetActive(false); // desativa ao fim

                // NOVO CÓDIGO DE DERROTA AQUI
                if (gameOverScreen != null)
                {
                    gameOverScreen.SetActive(true); // Ativa a tela de Game Over
                    Time.timeScale = 0f; // PAUSA O JOGO
                    Debug.Log("Fim de Jogo: Tempo Esgotado!");
                }
            }
        }
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        // ... (Seu código de formatação do tempo permanece o mesmo)
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}