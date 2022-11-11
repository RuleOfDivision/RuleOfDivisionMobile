using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mve : MonoBehaviour
{
    public Joystick joystick;
    public float runSpeed = 10f;
    float horizontalMove;
    float verticalMove;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //joystick sensitivity
        if(joystick.Horizontal >= .2f)
        {
            horizontalMove = runSpeed;
        }
        else    
            //the same but inverse
            if(joystick.Horizontal <= -.2f)
            {
                horizontalMove = -runSpeed;
            }
            else
                horizontalMove = 0f;

        if(joystick.Vertical <= -.2f)
        {
            verticalMove = -runSpeed;
        }
        else
            if(joystick.Vertical >= .2f)
            {
                verticalMove = runSpeed;
            }
            else
                verticalMove = 0f;
   
        Vector3 move = new Vector3 (horizontalMove,verticalMove,0f);
        rb.MovePosition(rb.position + move);
    }
}
