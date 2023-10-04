using UnityEngine;

public class FPSController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0.0f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Player movement
        float moveForward = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;
        float moveSideways = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        Vector3 movement = transform.forward * moveForward + transform.right * moveSideways;
        characterController.Move(movement);

        // Player rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);

        transform.Rotate(Vector3.up * mouseX);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }
}
