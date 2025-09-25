using UnityEngine;

public class ItensColetaveis : MonoBehaviour
{
    public string itemName;
    public int itemId;
    public string description;
    public Sprite icon;
    public int value;

    private bool jogadorProximo = false;
    private GameObject jogador;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = true;
            jogador = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jogadorProximo = false;
            jogador = null;
        }
    }

    private void Update()
    {
        if (jogadorProximo && Input.GetKeyDown(KeyCode.E))
        {
            Inventory inventory = jogador.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.AddItem(itemName, itemId, description, icon, value);

                // Tocar som de coleta
                SoundScript som = jogador.GetComponent<SoundScript>();
                if (som != null)
                {
                    som.TocarSomDeColeta();
                }

                Destroy(gameObject); // Remove o item da cena
            }
        }
    }
}
