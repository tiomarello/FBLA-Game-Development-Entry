using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    CharacterController PlayerController;

    public float speed;
    public float jumpSpeed;
    public float gravityConstant;
    public float gravityLimit;

    private float currentGravity;
    private float airTime;
    private bool isJumping;
   
    //The code runs when game firsts starts
    private void Start()
    {
        //Component Intialization//

        //We initialize our variables by using GetComponent, assuming these components are already on the GameObject
        PlayerController = GetComponent<CharacterController>();

        //Variable Initilization//
        currentGravity = 0;
        airTime = 0;
    }

    private void Update()
    {
      
        PlayerController.Move(GetPlayerInput());
        
    }


    //Returns Vector3 value with Playerinput on the X axis, as well as
    //Processing it by it multiplying it by speed and time.deltaTime/
    //applying gravity depending on whether the CharacterController is grounded
    Vector3 GetPlayerInput()
    {
        if (IsGrounded())
        {
            isJumping = false;
            currentGravity = 0;
            airTime = 0;
        }
        else
        {
            airTime += Time.deltaTime;
            currentGravity = currentGravity - gravityConstant;

            //We set an upperbound to how large currentGravity can be to limit falling speed
            if(currentGravity >= gravityLimit &&  !isJumping)
            {
                currentGravity = gravityLimit;
            }
            
        }

        if(Input.GetKeyUp(KeyCode.Space) && IsGrounded() || Input.GetKeyUp(KeyCode.Space) && airTime<0.2f)
        {
            isJumping = true;
            currentGravity = jumpSpeed;
        }
        if (IsCeiling())
        {
            currentGravity = -2;
        }
        Vector3 PlayerInputVector = new Vector3(Input.GetAxis("Horizontal") * speed, currentGravity, 0);
        PlayerInputVector *= Time.deltaTime;
        return (PlayerInputVector);

    }

    bool IsCeiling()
    {
        RaycastHit Hit;
        Ray ray = new Ray();

        ray.direction = Vector3.up;
        ray.origin = transform.position;

        if (Physics.Raycast(ray, out Hit, 1.5f))
        {
            if (Hit.collider.tag == "Ground")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else
        {
            return (false);
        }
    }

    bool IsGrounded()
    {
        RaycastHit Hit;
        Ray ray = new Ray();
         
        ray.direction = Vector3.down;
        ray.origin = transform.position;
        
        if(Physics.Raycast(ray, out  Hit, 1.5f))
        {
            if (Hit.collider.tag == "Ground")
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }
        else
        {
            return (false);
        }
    }

}
