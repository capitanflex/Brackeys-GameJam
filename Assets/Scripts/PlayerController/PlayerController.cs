using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float speedMovement;
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask groundMask;
    
    private float distanceToGround = 0.4f;
    public float gravity;
    private float powerJump = 5f;
    
    private Vector3 velocity;

    private bool isGrounded;
    
    private void FixedUpdate()
    {
        MovePlayer();
        GravityPlayerAndJump();
        IsGrounded();
    }
    
    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.forward * z + transform.right * x;
        characterController.Move(move * (speedMovement * Time.deltaTime));
    }

    private void GravityPlayerAndJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = powerJump;
        }
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void IsGrounded()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, distanceToGround, groundMask);
    }
}
