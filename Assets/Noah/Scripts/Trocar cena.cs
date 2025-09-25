using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Nome da cena para onde voc� quer ir
    public string nomeDaCena;

    public void TrocarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
    }
}