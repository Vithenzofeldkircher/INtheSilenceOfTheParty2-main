using UnityEngine;

public class Tezto2 : MonoBehaviour
{
    [TextArea(2, 5)]
    public string[] lines;
    private bool hasInteracted = false;

    private void Start()
    {
        // Se quiser iniciar o di?logo automaticamente no Start:
        Interactede();
    }

    void Interactede()
    {
        if (hasInteracted) return;

        hasInteracted = true;
        TextManager.Instance.StartDialogue(lines);
    }
}