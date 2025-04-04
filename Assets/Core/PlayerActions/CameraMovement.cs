using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    [SerializeField] private float sensivity;
    public Transform lookAt;
    public float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, -89f, 89f);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);
    }

    
}
