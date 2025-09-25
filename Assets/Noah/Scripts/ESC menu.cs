using UnityEngine;

public class MenuPause : MonoBehaviour
{
    public GameObject menuPainel;  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Alterna o estado do painel (ativa/desativa)
            menuPainel.SetActive(!menuPainel.activeSelf);
        }
    }
}