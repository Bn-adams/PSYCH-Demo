using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private float HI;
    private float VI;
    

    public Rigidbody rb;
    //public float MS;
    
    private Vector3 moveDirection;
    public Transform orientation;

    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance;
    public float fallMultiplier; 


    public float jumpForce = 5f; // adjustable jump force
    private bool isGrounded;
    private bool isFalling;
   


    private PlayerStats stats;

    public bool isOutside;
    public bool isRecharging;
    public bool isStatic;
   
    
    
    public float chargeRate;
    public Image StamBar;
    private Coroutine recharge;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        stats.StaminaCount = stats.MaxStamina;
        
    }
    private void FixedUpdate()
    {
        if (rb != null)
        {
            CheckGrounded();
            GetMovement();
            IsRunning();
            SetMovement();
            Jump();
            FallCheck();
            //Debug.Log(isRecharging);
            Debug.Log(isOutside);
        }

    }
    // Update is called once per frame
    void Update()
    {
        outSideCheck();
    }
    private IEnumerator RechargeStamina()
    {
        yield return new WaitForSeconds(2f);

        while(stats.StaminaCount < stats.MaxStamina)
        {
            

            stats.StaminaCount += chargeRate / 10f;
            if (stats.StaminaCount > stats.MaxStamina) stats.StaminaCount = stats.MaxStamina;
            StamBar.fillAmount = stats.StaminaCount / stats.MaxStamina;
            isRecharging = true;
            yield return new WaitForSeconds(0.1f);
        }
        MaxStamCheck();
    }
    void MaxStamCheck()
    {
       if(stats.StaminaCount == stats.MaxStamina)
        {
            isRecharging = false;
            
        }
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
            Debug.Log("IsJumping");
            rb.AddForce(Vector3.up * (2*jumpForce), ForceMode.Impulse);
        }
    }
    //Apply the Movement in the Correct orientation
    void SetMovement()
    {
        if (stats.StaminaCount > stats.MinStamina)
        {
            if (HI != 0 || VI != 0)
            {
                isStatic = false;
                moveDirection = orientation.right * HI + orientation.forward * VI;

                Vector3 moveVelocity = moveDirection * stats.MS;
                moveVelocity.y = rb.velocity.y;
                rb.velocity = moveVelocity;

                //Debug.Log("sending input");
                StaminaCheck();

                
            }
            else
            {
                Debug.Log("NoInput");
                isStatic = true;
                //rb.velocity = new Vector3(0, (rb.velocity.y), 0); // stop horizontal movement if no input
            }


        }
        
    }
    void IsRunning()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            stats.MS = 30f;
        }
        else
        {
            stats.MS = 15f;
        }

        
    }
    void StaminaCheck()
    {
        if(stats.MS > 16f)
        {
            stats.StaminaCount -= stats.RunCost * Time.deltaTime; // applies walk cost while moving every second

        }
        else
        {
            stats.StaminaCount -= stats.WalkCost * Time.deltaTime; // applies walk cost while moving every second
        }

       
        if (stats.StaminaCount < stats.MinStamina) stats.StaminaCount = 0;

        StamBar.fillAmount = stats.StaminaCount / stats.MaxStamina;

        if (recharge != null) StopCoroutine(recharge);
        recharge = StartCoroutine(RechargeStamina());
    }
    void CheckGrounded()
    {
      
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log("IsGrounded");
        isFalling = false;
    }

    void FallCheck()
    {

        if (!isGrounded && !isFalling)
        {
            StartCoroutine(FallChecker());


        }
    }
    IEnumerator FallChecker()
    {
        yield return new WaitForSeconds(1);
        // Apply extra gravity when falling
        if (rb.velocity.y < 1.5)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
        Debug.Log("isFalling");
        isFalling = true; 

    }

    void outSideCheck()
    {
        if(transform.position.z < 100)
        {
            isOutside = false;
        }
        else
        {
            isOutside = true;
        }
    }
}

