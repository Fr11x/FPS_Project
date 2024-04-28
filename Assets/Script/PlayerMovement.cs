using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // speed and jump control
    public float speed = 5f;
    public float shiftSpeed = 2f;
    private float currentSpeed;
    public float jumpForce = 5f;
    
    private Rigidbody rb;
    
    // Checkground 
    private bool isGrounded;
    public float distToGround = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // sprint code
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = speed * shiftSpeed;
        }
        else
        {
            currentSpeed = speed;
        }
        
        // jump action
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity += (Vector3.up * jumpForce) ;
        }
    }

    private void FixedUpdate()
    {
        // movement part
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 move = horizontalInput * transform.right + verticalInput * transform.forward;
        rb.MovePosition(transform.position + move * Time.fixedDeltaTime * currentSpeed);
        groundCheck();
        

    //check if we're on the ground or not with raycast    
    void groundCheck()
    {  
        if (Physics.Raycast(transform.position,Vector3.down,distToGround + 0.01f))
        {
            isGrounded = true;
            Debug.Log("grounded");
        }
        else
        {
            isGrounded = false;
            Debug.Log("not grounded");
        }
    }
    }
}
