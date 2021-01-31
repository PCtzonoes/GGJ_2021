//Author: Kingyan Incorporated

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float standingSpeed = 3f;
    public float crouchingSpeed = 1.5f;
    public float runningSpeed = 6f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float crouchingHeight;
    public float jumpVelocity;
    public float fallMultiplier;
    public float lowJumpMultiplier;

    AudioManager audioManager;
    Vector3 velocity;
    bool isGrounded;
    bool isCrouching;
    bool crouchZone;
    bool staminaBarExists;
    float standingHeight;
    float speed;
    float staminaUsage = 1f;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        standingHeight = controller.height;
        speed = standingSpeed;

        //Makes the cursor invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if(StaminaBar.instance != null)
        {
            staminaBarExists = true;
        } else
        {
            Debug.LogWarning("Stamina bar was not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //basic first person controller
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //step sound
        if(isGrounded && (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && !audioManager.IsPlaying("step"))
        {
            audioManager.PlaySound("step");
        }


        //crouching
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;

            CheckCrouch();
        }

        //running
        if (staminaBarExists)
        {
            if (!isCrouching && StaminaBar.instance.canRun)
            {
                if (Input.GetKey(KeyCode.LeftShift) && (Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f))
                {
                    speed = runningSpeed;
                    StaminaBar.instance.UseStamina(staminaUsage);
                    if (!audioManager.IsPlaying("breath"))
                    {
                        audioManager.PlaySound("breath");
                    }
                }
            }
            if (Input.GetKeyUp(KeyCode.LeftShift) || !StaminaBar.instance.canRun)
            {
                speed = standingSpeed;
            }
        }

        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = jumpVelocity;
        }

        if(controller.velocity.y < 0)
        {
            velocity += Vector3.up * gravity * (fallMultiplier - 1) * Time.deltaTime;
        } 
        else if (controller.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            velocity += Vector3.up * gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void CheckCrouch()
    {
        if (isCrouching == true)
        {
            controller.height = crouchingHeight;
            speed = crouchingSpeed;
        }
        else
        {
            if (!crouchZone)
            {
                controller.height = standingHeight;
                speed = standingSpeed;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "crouchZone")
        {
            crouchZone = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "crouchZone")
        {
            crouchZone = false;
        }
    }
}
