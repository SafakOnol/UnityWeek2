using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Character : MonoBehaviour
{
    Rigidbody rb; //can't use rigidbody as variable name since it's overriding system variables.

    // Used to control 'Character' movement
    float currentSpeed;
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpSpeed;

    float moveForward;
    float moveSide;

    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckDistance;



    // Start is called before the first frame update
    void Start()
    {
        name = "Character";

        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        if(walkSpeed <= 0)
        {
            walkSpeed = 8.0f;
            Debug.Log(name + ": walkSpeed not set. Defaulting to " + walkSpeed);
        }

        if(sprintSpeed <= 0)
        {
            sprintSpeed = 16.0f;
            Debug.Log(name + ": springSpeed not set. Defaulting to " + sprintSpeed);
        }

        if (jumpSpeed <= 0)
        {
            jumpSpeed = 5.0f;
            Debug.Log(name + ": jumpSpeed not set. Defaulting to " + jumpSpeed);
        }

        if (!groundCheck)
        {
            Debug.LogError(name + ": Missing groundCheck");
        }

        if (groundCheckDistance <= 0)
        {
            groundCheckDistance = 0.3f;

            Debug.Log(name + ": groundCheckDistance not set. Defaulting to " + groundCheckDistance);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(groundCheck)
        {
            isGrounded = Physics.Raycast(groundCheck.position, -groundCheck.up, groundCheckDistance);

            Debug.DrawRay(groundCheck.position, -groundCheck.up * groundCheckDistance, Color.red);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            if (currentSpeed != sprintSpeed)
                currentSpeed = sprintSpeed;
        }
        else
            currentSpeed = walkSpeed;
        
        // sets default values for W,A,S,D and arrow keys
        moveForward = Input.GetAxis("Vertical") * currentSpeed;
        moveSide = Input.GetAxis("Horizontal") * currentSpeed;

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            jump();
        }
        
    }

    void FixedUpdate()
    {
        rb.velocity = (transform.forward * moveForward) + (transform.right * moveSide) + (transform.up * rb.velocity.y);
    }

    void jump()
    {
        Debug.Log("Jumping");

        rb.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
    }

    // Usage Rules:
    // - Both GameObjects in Scene needs to have Colliders
    // - One or Both GameObjects need a Rigidbody
    // - Called once when collision starts

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter: " + collision.gameObject.name);
        Debug.Log("OnCollisionEnter: " + collision.gameObject.tag);
    }

    // Usage Rules:
    // - Both GameObjects in Scene needs to have Colliders
    // - One or Both GameObjects need a Rigidbody
    // - Called as long as collision happens

    void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay: " + collision.gameObject.name);
        Debug.Log("OnCollisionStay: " + collision.gameObject.tag);
    }

    // Usage Rules:
    // - Both GameObjects in Scene needs to have Colliders
    // - One or Both GameObjects need a Rigidbody
    // - Called once when collision ends

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit: " + collision.gameObject.name);
        Debug.Log("OnCollisionExit: " + collision.gameObject.tag);
    }
}
