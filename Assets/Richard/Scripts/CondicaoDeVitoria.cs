using UnityEngine;

public class CondicaoDeVitoria : MonoBehaviour
{
    public Inventory inventory; // arrasta o Inventory aqui no inspector
    public TimerScript timerScript; // arrasta o TimerScript no inspector
    public GameObject porta;
    public GameObject vitoria;

    private void Start()
    {
        porta.SetActive(true);
        vitoria.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Corrigido
        {
            // Verifica se o jogador coletou todos os itens poss�veis
            if (inventory.items.Count == inventory.maxSlots)
            {
                // Verifica se ainda h� tempo no cron�metro
                if (timerScript.timerRemaining > 0)
                {
                    vitoria.SetActive (true);
                    porta.SetActive(false);
                    Debug.Log(" U did it!");
                }
                else
                {
                    Debug.Log(" Tempo acabou!");
                }
            }
            else
            {
                Debug.Log("Voc� ainda n�o pegou todos os itens!");
            }
        }
    }
}
