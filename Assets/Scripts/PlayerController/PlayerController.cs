using System;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float trapForce;
    [SerializeField] private Transform checkGround;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform Trap;
    [SerializeField] private Animator animator;
    
    [Header("Player Settings")]
    [SerializeField] private float speedMovement;
    [SerializeField] private float powerJump = 5f;
    [SerializeField] private float gravity;
    
    
    private float distanceToGround = 0.4f;
    private bool isFirstJump;
    
    private Vector3 velocity;

    private bool isGrounded;

    public bool canMove = true;
    
    
    private void Update()
    {
        if (canMove)
        {

            MovePlayer();
            GravityPlayerAndJump();
            IsGrounded();
        }
    }
    
    private void MovePlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.forward * z + transform.right * x;
        characterController.Move(move * (speedMovement * Time.deltaTime));
        if (x > 0 || z > 0)
        {
            animator.SetBool("isWalking",true);
        }
        else
        {
            animator.SetBool("isWalking",false);
        }
    }

    private void GravityPlayerAndJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                isFirstJump = false;
                velocity.y = powerJump;
            }

            if (!isGrounded && !isFirstJump)
            {
                velocity.y = powerJump;
                isFirstJump = true;
            }
            
        }
        velocity.y -= gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    private void IsGrounded()
    {
        isGrounded = Physics.CheckSphere(checkGround.position, distanceToGround, groundMask);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            velocity.y = Trap.position.y * trapForce;
            velocity.x = -Trap.position.x;
            velocity.z = Trap.position.z;
        }
    }
}
