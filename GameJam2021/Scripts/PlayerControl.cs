using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float speed = 0.0f;
    public float maxSpeed = 3.0f;
    public float accl = 0.5f;

    private float maxBattery = 100;
    private float batteryConsumption = 1;
    private float currentBattery = 100;

    private float inputX;
    private float inputY;
    private float xMove;
    private float yMove;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
        xMove = 0.0f;
        yMove = 0.0f;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        inputX = movementVector.x;
        inputY = movementVector.y;
    }

    private void FixedUpdate()
    {
        //movement on X
        xMove += inputX * accl;

        //if no input, come to stop
        if(inputX == 0)
        {
            xMove = xMove * accl;
        }

        //don't surpass max speeds
        if (xMove > maxSpeed)
        {
            xMove = maxSpeed;
        }
        else if (xMove < -maxSpeed)
        {
            xMove = -maxSpeed;
        }

        //movement on Z but am too lazy to chance the wording.
        yMove += inputY * accl;

        //if no input, come to stop
        if (inputY == 0)
        {
            yMove = yMove * accl;
        }

        //don't surpass max speeds
        if (yMove > maxSpeed)
        {
            yMove = maxSpeed;
        }
        else if (yMove < -maxSpeed)
        {
            yMove = -maxSpeed;
        }

        Vector3 newPosition = new Vector3(xMove * speed * Time.fixedDeltaTime, 0.0f, yMove * speed * Time.fixedDeltaTime);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition, Space.World);
    }

}