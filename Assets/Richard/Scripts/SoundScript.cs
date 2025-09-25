using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip somColeta;

    public void TocarSomDeColeta()
    {
        if (somColeta != null && audioSource != null)
        {
            audioSource.PlayOneShot(somColeta);
            Debug.Log("Som de coleta executado!");
        }
    }
}

