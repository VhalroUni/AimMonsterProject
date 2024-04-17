using UnityEngine;

public class BadCamera : MonoBehaviour
{
    public Transform cameraTransform;
    public float moveSpeed = 5f;
    public float boundaryRadius = 5f;
    public float maxSpeed = 10f;
    public float CTP = 0.1f;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        // Mover el personaje
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 moveInput = new Vector3(moveHorizontal, 0f, moveVertical);
        _targetPosition += moveInput * moveSpeed * Time.deltaTime;

        // Limitar el movimiento dentro de los límites de la arena
        //_targetPosition.x = Mathf.Clamp(_targetPosition.x, -boundaryRadius, boundaryRadius);
        //_targetPosition.z = Mathf.Clamp(_targetPosition.z, -boundaryRadius, boundaryRadius);

        // Actualizar la posición de la cámara suavemente
        Vector3 cameraTargetPosition = new Vector3(_targetPosition.x, cameraTransform.position.y, _targetPosition.z);
        cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraTargetPosition, CTP);

        // Mover el personaje suavemente
        //transform.position = Vector3.Lerp(transform.position, _targetPosition, maxSpeed * Time.deltaTime);
    }
}
