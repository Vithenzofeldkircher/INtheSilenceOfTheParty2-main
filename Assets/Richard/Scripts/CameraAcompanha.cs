using UnityEngine;

public class CameraAcompanha : MonoBehaviour
{
    public Transform target;       // O player ou trailer
    public Vector3 offset;         // Distância da câmera em relação ao alvo
    public float smoothSpeed = 0.125f;

    void LateUpdate()
    {
        // Verifica se o target ainda existe
        if (target == null)
        {
            return; // Sai do método se o alvo não existe mais
        }

        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target); // Opcional
    }
}
