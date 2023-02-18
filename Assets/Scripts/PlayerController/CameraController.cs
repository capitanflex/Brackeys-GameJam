using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private float mouseSensetive;
    
    private float yRotation;

    public bool canMove = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (canMove)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            yRotation -= mouseY;
            yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        
            transform.localRotation = Quaternion.Euler(yRotation, 0, 0);
            playerBody.Rotate(Vector3.up  * (mouseX * mouseSensetive));
        }
    }
}
