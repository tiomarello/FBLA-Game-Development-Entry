using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    CharacterController PlayerController;

    /// <summary>
    /// Player speed in units per second.
    /// </summary>
    public float speed;
    /// <summary>
    /// Player jump speed in inital units per second.
    /// </summary>
    public float jumpSpeed;
    /// <summary>
    /// Acceleration of gravity.
    /// </summary>
    public float gravityConstant;
    /// <summary>
    /// Limit on how fast player can fall.
    /// </summary>
    public float gravityLimit;
    /// <summary>
    /// How zoomed in the camera is while moving around.
    /// </summary>
    public float CameraSizeOriginal;
    /// <summary>
    /// How zoomed in the camera while zoomed out
    /// </summary>
    public float CameraSizeZoomed;
 

    private float currentGravity;
    private float airTime;
    private float currentSpeed;
    private float currentCameraSize;
    private bool isJumping;
    
    //The code runs when game firsts starts
    private void Start()
    {
        //Component Intialization//
        PlayerController = GetComponent<CharacterController>();

        //Variable Initilization//
        currentGravity = 0;
        airTime = 0;
        currentSpeed = speed;
        currentCameraSize = CameraSizeOriginal;
    }

    private void Update()
    {
       PlayerController.Move(GetPlayerInput());    
    }
    private void FixedUpdate()
    {
        IsPlatformed();
    }
    /// <summary>
    ///Returns Vector3 value with Playerinput on the X axis, as well as
    ///Processing it by it multiplying it by speed and time.deltaTime/
    ///applying gravity depending on whether the CharacterController is grounded
    /// </summary>
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

            //Set an upperbound to how large currentGravity can be to limit falling speed
            if(currentGravity >= gravityLimit &&  !isJumping)
            {
                currentGravity = gravityLimit;
            }
            
        }

        //Checks whether Player is inputing space and is either on a surface,
        //or just left surface, applying a positive force upward for a jump
        if(Input.GetKeyUp(KeyCode.Space) && IsGrounded() || Input.GetKeyUp(KeyCode.Space) && airTime<0.2f)
        {
            isJumping = true;
            currentGravity = jumpSpeed;
        }

        //Causes Player to bounce off of ceiling 
        if (IsCeiling())
        {
            currentGravity = -PlayerController.velocity.y;
        }


        Vector3 PlayerInputVector = new Vector3(Input.GetAxis("Horizontal") * currentSpeed, currentGravity, 0);
        PlayerInputVector *= Time.deltaTime;
        return (PlayerInputVector);

    }
    ///<summary>
    ///Returns true/false if there is surface directly above Player
    ///</summary>
    bool IsCeiling()
    {
        RaycastHit Hit;
        Ray ray = new Ray();

        ray.direction = Vector3.up;
        ray.origin = transform.position;

        if (Physics.Raycast(ray, out Hit, 1.5f))
        {
            if (Hit.collider.CompareTag("Ground") || Hit.collider.CompareTag("Platform"))
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

    /// <summary>
    /// Returns true/false if there is surface directly below Player.
    /// Use instead of CharacterController.isGrounded, more reliable
    /// </summary>
    bool IsGrounded()
    {
        RaycastHit Hit;
        Ray ray = new Ray();
         
        ray.direction = Vector3.down;
        ray.origin = transform.position;
        
        if(Physics.Raycast(ray, out  Hit, 1.5f))
        {
            if (Hit.collider.CompareTag("Ground") || Hit.collider.CompareTag("Platform"))
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
    void IsPlatformed()
    {
        RaycastHit Hit;
        Ray ray = new Ray();

        ray.direction = Vector3.down;
        ray.origin = transform.position;
        
        if (Physics.Raycast(ray, out Hit, 1.5f))
        {
            if (Hit.collider.CompareTag("Platform"))
            {
                transform.SetParent(Hit.collider.transform);
            }
            else
            {
                transform.SetParent(null);
            }
        }
        else
        {
            transform.SetParent(null);
        }
    }
}
