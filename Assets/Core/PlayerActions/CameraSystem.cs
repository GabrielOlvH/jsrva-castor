using UnityEngine;
using UnityEngine.InputSystem;

public class CameraSystem : MonoBehaviour
{
    [SerializeField]
    float sensitivity;
    private Vector2 mouseInput;
    private float pitch;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //Movement for testing
        Vector3 inputDir = new Vector3(0,0,0);

        if(Input.GetKey(KeyCode.W)){ inputDir.z = +1f;}
        if(Input.GetKey(KeyCode.S)){ inputDir.z = -1f;}
        if(Input.GetKey(KeyCode.A)){ inputDir.x = -1f;}
        if(Input.GetKey(KeyCode.D)){ inputDir.x = +1f;}
        
        Vector3 moveDir = transform.forward *inputDir.z +transform.right * inputDir.x;
        float moveSpeed = 10f;
        transform.position += moveDir*moveSpeed*Time.deltaTime;

        transform.Rotate(Vector3.up, mouseInput.x*sensitivity*Time.deltaTime);
        pitch -= mouseInput.y *sensitivity *Time.deltaTime;
        pitch = Mathf.Clamp(pitch,-90f,90f);
        transform.localEulerAngles = new Vector3(pitch, transform.localEulerAngles.y, 0f);

    }
    
    public void OnMouseMove(InputAction.CallbackContext context)
    {
        mouseInput = context.ReadValue<Vector2>();
    }
}
