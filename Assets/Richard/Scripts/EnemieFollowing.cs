using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;

public class EnemieFollowing : MonoBehaviour
{
    [SerializeField] public float speed = 9f;
    [SerializeField] public Transform target;

    [SerializeField] public GameObject panelLose;        // Arraste o painel da UI no Inspector
    [SerializeField] public TimerScript timerScript;     // Arraste o objeto com TimerScript no Inspector

    private bool enemieFollow = false;
    public bool playerLost = false;

    void Start()
    {

        // Garante que o target seja atribuído mesmo se não tiver sido no Inspector
        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                target = playerObj.transform;
        }
    }

    void Update()
    {
        if(target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed);
        }
        
        //checa se o tempo acabou
        if (timerScript != null && !timerScript.timerIsRunning)
        {
            enemieFollow = true;
        }

        if (enemieFollow && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void PlayerLose()
    {
        playerLost = true;         // Marca que o jogador já perdeu (evita repetição)
        if (panelLose != null)
            panelLose.SetActive(true); // Mostra o painel de derrota na tela
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (playerLost && other.CompareTag("palyer"))
        {
            PlayerLose();
            Destroy(target.gameObject);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            
            if (panelLose != null)
                panelLose.SetActive(true);
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}