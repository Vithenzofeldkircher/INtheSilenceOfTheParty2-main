using UnityEngine;
using UnityEngine.UI;

public class EnemieFollowing : MonoBehaviour
{
    [SerializeField] public float speed = 9f;
    [SerializeField] public Transform target;

    [SerializeField] public GameObject panelLose;        // Arraste o painel da UI no Inspector
    [SerializeField] public TimerScript timerScript;     // Arraste o objeto com TimerScript no Inspector

    private bool enemieFollow = false;

    void Start()
    {
        if (panelLose != null)
        {
            panelLose.SetActive(false);
        }

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
        if (timerScript != null && !timerScript.timerIsRunning)
        {
            enemieFollow = true;
        }

        if (enemieFollow && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (panelLose != null)
                panelLose.SetActive(true);
            Destroy(target.gameObject);
            Destroy(gameObject);
        }
    }
}