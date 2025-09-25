using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    public GameObject panelCreditos;
    private void Start()
    {
        panelCreditos.SetActive(false);
    }
    public void CenaJogo ()
    {
        SceneManager.LoadScene("R");
    }
    public void CenaInicial ()
    {
        SceneManager.LoadScene("TelaDeTitulo");
    }
    public void Panel ()
    {
        panelCreditos.SetActive(true);
    }
    public void fecharPanel()

    {
        panelCreditos.SetActive(false);
    }
}
