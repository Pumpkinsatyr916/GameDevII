using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    //Debug
    //public TMP_Text debug_text;
    
    //Camera Variables
    public Camera cam;
    private Vector2 look_input = Vector2.zero;
    private float look_speed = 60f;
    private float horizontal_look_angle = 0f;
    public bool invert_x = false;
    public bool invert_y = false;
    public int invert_factor_x = 1;
    public int invert_factor_y = 1;
    [Range(0.01f, 1f)]public float sensitivity;

    // player Input
    /*private Vector2 move_input;
    private bool grounded; 

    //movement 
    private CharacterController characterController;
    private Vector3 player_velocity;
    private Vector3 wish_dir = Vector3.zero;
    public float max_speed = 6f;
    public float acceleration = 60f;
    public float gravity = 15f;
    public float stop_speed = 0.5f;
    public float jump_impulse = 10f;
    public float friction = 4f;*/

    // Start is called before the first frame update
    void Start()
    {
        //hide the mouse
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //invert cam
        if (invert_x) invert_factor_x = -1;
        if (invert_y) invert_factor_y = -1;

        //get ref to character controller compented 
        //characterController = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
       /* debug_text.text = "Wish Dir: " + wish_dir.ToString();
        debug_text.text += "\nVelocity: " + player_velocity.ToString();
        debug_text.text += "\nSpeed: " + new Vector3(player_velocity.x, 0, player_velocity.z).magnitude.ToString();
        debug_text.text += "\nGround: " + grounded.ToString();*/

        Look();

    }

    /*private void FixedUpdate()
    {
        // Find wish_dir.
        wish_dir = transform.right * move_input.x + transform.forward * move_input.y;
        wish_dir = wish_dir.normalized;

        grounded = characterController.isGrounded;
        if(grounded)
        {
            player_velocity = MoveGround(wish_dir, player_velocity);
        }
        else
        {
            player_velocity = MoveAir(wish_dir, player_velocity);
        }

        //gravity
        player_velocity.y -= gravity * Time.deltaTime;
        if(grounded && player_velocity.y < 0)
        {
            player_velocity.y = -2;
        }

        characterController.Move(player_velocity * Time.deltaTime);
    }*/

    public void GetLookInput(InputAction.CallbackContext context)
    {
        look_input = context.ReadValue<Vector2>();

    }

    private void Look()
    {
        //left/Right
        transform.Rotate(Vector3.up,look_input.x * look_speed * Time.deltaTime * invert_factor_x * sensitivity);

        //Up/down
        float angle = look_input.y * look_speed * Time.deltaTime * invert_factor_y * sensitivity;
        horizontal_look_angle -= angle;
        horizontal_look_angle = Mathf.Clamp(horizontal_look_angle, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(horizontal_look_angle, 0, 0);
    }
    /*public void GetMoveInput(InputAction.CallbackContext context)
    {
        move_input = context.ReadValue<Vector2>();

    }
   /* public void GetJumpInput(InputAction.CallbackContext context)
    {
        Jump();

    }*/
    /*public void Jump()
    {
        if (grounded)
        {
            player_velocity.y = jump_impulse;
        }
    }*/

  /*  private Vector3 Accelerate(Vector3 wish_dir, Vector3 current_velocity, float  accel, float mad_speed)
    {
        float proj_speed = Vector3.Dot(current_velocity, wish_dir);
        float accel_speed = accel * Time.deltaTime;

        if(proj_speed + accel_speed > max_speed)
        {
            accel_speed = max_speed - proj_speed;
        }

        //return new speed 
        return current_velocity + (wish_dir * accel_speed);
    }

    private Vector3 MoveAir(Vector3 wish_dir, Vector3 current_velocity)
    {
        return Accelerate(wish_dir, current_velocity, acceleration, max_speed);
    }

    private Vector3 MoveGround(Vector3 wish_dir, Vector3 current_velocity)
    {
        Vector3 new_velocity = new Vector3 (current_velocity.x, 0, current_velocity.z);

        float speed = new_velocity.magnitude;
        if (speed <= stop_speed)
        {
            new_velocity = Vector3.zero;
            speed = 0;
        }
        if (speed != 0)
        {
            float drop = speed * friction * Time.deltaTime;
            new_velocity *= Mathf.Max(speed - drop, 0) / speed;
        }
        new_velocity = new Vector3(new_velocity.x, current_velocity.y, new_velocity.z);

        return Accelerate(wish_dir, new_velocity, acceleration, max_speed);
    }*/
}
