using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float HI;
    private float VI;

    public Rigidbody rb;
    public float MS;
    private Vector3 moveDirection;
    public Transform orientation;

    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance;

    public float jumpForce = 5f; // adjustable jump force
    private bool isGrounded;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            CheckGrounded();
            GetMovement();
            SetMovement();
            Jump();
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    //Get and Store the Input Axis
    void GetMovement()
    {
        HI = Input.GetAxis("Horizontal");
        VI = Input.GetAxis("Vertical");
    }
    
    void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            Debug.Log("IsJump");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
    //Apply the Movement in the Correct orientation
    void SetMovement()
    {

        if (HI != 0 || VI != 0)
        {
            moveDirection = orientation.right * HI + orientation.forward * VI;
           
            Vector3 moveVelocity = moveDirection * MS;
            moveVelocity.y = rb.velocity.y;
            rb.velocity = moveVelocity;

           
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0); // stop horizontal movement if no input
        }
    }
    void CheckGrounded()
    {
      
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //Debug.Log("IsGrounded");
    }


}

