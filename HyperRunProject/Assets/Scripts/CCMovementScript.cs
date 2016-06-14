using UnityEngine;
using System.Collections;


public class CCMovementScript : MonoBehaviour
{

   
    public Transform CameraTransform;
    // public float speed = 2.0f;
    public float topSpeed = 10f;
    public float speed = 1.0f;
    public float jumpSpeed = 1.0f;
    public float gravity = 20.0f;
    float drag = 50.0f;
    float diagonalDrag = 75.0f;

    private bool isMoving = false;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Rigidbody myrigidbody;
    private CharacterController controller;

    // Update is called once per frame
    void Start()
    {
        myrigidbody = this.GetComponent<Rigidbody>();
        myrigidbody.freezeRotation = true;
        controller = this.GetComponent<CharacterController>();
   
    }
  
    bool IsGrounded()
    {
        if(Physics.Raycast(transform.position, -transform.up, 2f))
        {
            Debug.Log("hitting");
            return true;
        }
        else
        {
            return false;
        }
    }

    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal")*  speed;
        float verticalInput = Input.GetAxisRaw("Vertical")* speed;

        
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
       else  if (horizontalInput < 0 && verticalInput < 0)
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, diagonalDrag * Time.deltaTime);
        }
        else
        {
            velocity = Vector3.MoveTowards(velocity, Vector3.zero, drag * Time.deltaTime);
        }
        velocity += moveDirection;
        if(velocity.magnitude > topSpeed)
        {
            velocity = velocity.normalized * topSpeed;
        }
      
        controller.Move((velocity + new Vector3 (0.0f, -9.8f, 0.0f))* Time.deltaTime);
        Debug.Log(velocity);


        if (targetDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

    }
}


