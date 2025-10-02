using UnityEngine;

public class CondicaoDeVitoria : MonoBehaviour
{
    public Inventory inventory;
    public TimerScript timerScript; // Arrastado do objeto com o TimerScript
    public GameObject porta;
    public GameObject vitoria; // Tela de Vitória/Win Screen

    // IMPORTANTÍSSIMO: Mude este valor no Inspector para o total exato de doces no seu nível!
    public int docesParaVitoria = 6; // Exemploo: se você tem 5 doces no cenário

    private void Start()
    {
        porta.SetActive(true);
        vitoria.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colidiu com: " + collision.name);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player tocou na porta!");

            // VERIFICAÇÃO CHAVE: O número de itens coletados é suficiente para vencer?
            if (inventory != null && inventory.items.Count >= docesParaVitoria)
            {
                vitoria.SetActive(true); // Ativa a tela de vitória
                porta.SetActive(false);  // Desativa a porta

                // NOVO: Se o jogador vence, o timer DEVE PARAR!
                if (timerScript != null)
                {
                    timerScript.timerIsRunning = false;
                    Time.timeScale = 0f; // PAUSA O JOGO NA VITÓRIA
                }

                Debug.Log("VITÓRIA! Doces Coletados: " + inventory.items.Count);
            }
            else
            {
                // Se não venceu, dê um feedback claro!
                Debug.Log($"Ainda faltam {docesParaVitoria - inventory.items.Count} doces! Doces Atuais: {inventory.items.Count}");
            }
        }
    }
}

