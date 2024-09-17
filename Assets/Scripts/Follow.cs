using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    private Vector3 offset;

    // Controla la velocidad de suavizado al seguir al jugador
    public float smoothSpeed = 0.125f;

    // Variable auxiliar para almacenar la posición de destino suavizada
    private Vector3 targetPositionSmoothed;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.transform.position;
        targetPositionSmoothed = target.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        // Puedes agregar aquí cualquier lógica adicional que necesites en Update()
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.transform.position + offset;

        // Solo ajusta la posición en el eje Y si el jugador está en el aire (por ejemplo, si está saltando)
        if (!IsPlayerGrounded())
        {
            targetPosition.y = transform.position.y;
        }

        // Interpola suavemente entre la posición actual y la posición de destino
        targetPositionSmoothed = Vector3.Lerp(targetPositionSmoothed, targetPosition, smoothSpeed * Time.deltaTime);

        transform.position = targetPositionSmoothed;
    }

    bool IsPlayerGrounded()
    {
        RaycastHit hit;
        float raycastDistance = 0.1f;
        return Physics.Raycast(target.transform.position, Vector3.down, out hit, raycastDistance);
    }
}
