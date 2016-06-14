using UnityEngine;
using System.Collections;


public class CCMovementScript : MonoBehaviour
{


    public Transform CameraTransform;
    // public float speed = 2.0f;
    public float topSpeed = 10f;
    public float speed = 1.0f;
    public float jumpSpeed = 20.0f;
    private float gravity = 120.0f;
    float drag = 100.0f;
    float diagonalDrag = 125.0f;

    private bool isMoving = false;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody myrigidbody;
    private CharacterController controller;

    public static bool isGrounded = false;
    // Update is called once per frame
    void Start()
    {
        myrigidbody = this.GetComponent<Rigidbody>();
        myrigidbody.freezeRotation = true;
        controller = this.GetComponent<CharacterController>();

    }


    void Update()
    {
        float horizontalInput = 0;
        float verticalInput = 0;
        
            horizontalInput = Input.GetAxisRaw("Horizontal") * speed*Time.deltaTime;
            verticalInput = Input.GetAxisRaw("Vertical") * speed*Time.deltaTime;

            Vector3 targetDirection = (horizontalInput * Camera.main.transform.right) + (verticalInput * Camera.main.transform.forward);
            moveDirection = Vector3.RotateTowards(moveDirection, targetDirection, 200 * Mathf.Deg2Rad * Time.deltaTime, 1000);

            if (horizontalInput > 0 && verticalInput > 0)
            {
                velocity = Vector3.MoveTowards(velocity, Vector3.zero, diagonalDrag * Time.deltaTime);
            }
            else if (horizontalInput > 0 && verticalInput < 0)
            {
                velocity = Vector3.MoveTowards(velocity, Vector3.zero, diagonalDrag * Time.deltaTime);
            }
            else if (horizontalInput < 0 && verticalInput > 0)
            {
                velocity = Vector3.MoveTowards(velocity, Vector3.zero, diagonalDrag * Time.deltaTime);
            }
            else if (horizontalInput < 0 && verticalInput < 0)
            {
                velocity = Vector3.MoveTowards(velocity, Vector3.zero, diagonalDrag * Time.deltaTime);
            }
            else
            {
                velocity = Vector3.MoveTowards(velocity, Vector3.zero, drag * Time.deltaTime);
            }
            velocity += moveDirection;
            if (velocity.magnitude > topSpeed)
            {
                velocity = velocity.normalized * topSpeed;
            }

            if (Input.GetButton("Jump"))
            {
            if (isGrounded == true)
            {
                Debug.Log("jumping");
                velocity.y = jumpSpeed;
            }
            }

            velocity.y -= gravity *Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);



            if (targetDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection);
            }


        }
    }



