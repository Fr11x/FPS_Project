using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private float sens = 100f;

    public Transform PlayerBody;

    private float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        // make invisible and locked the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * sens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sens * Time.deltaTime;
        // make the player rotate on y axes
        PlayerBody.Rotate(Vector3.up * mouseX);
        
        xRotation -= mouseY;
        transform.localRotation = Quaternion.Euler(xRotation,0,0);
        // player can only view the top and bottom vertically
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

    }
}
