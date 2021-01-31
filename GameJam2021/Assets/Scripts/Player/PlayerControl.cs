using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float speed = 0.0f;
    public float maxSpeed = 10.0f;
    public float accl = 0.5f;
    public GameObject flashlight;

    private Vector3 aimDirection;
    private bool lightOn = false;
    private double maxBattery = 100;
    private double batteryConsumption = 0.01;
    private double currentBattery = 100;

    private float inputX;
    private float inputY;
    private float xMove;
    private float yMove;

    private Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        xMove = 0.0f;
        yMove = 0.0f;
        flashlight.SetActive(false);
        aimDirection = transform.position;
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        inputX = movementVector.x;
        inputY = movementVector.y;
    }

    private void OnFire()
    {
        if (flashlight != null && currentBattery > 0)
        {
            lightOn = true;
            flashlight.SetActive(true);
        }
    }

    private void OnRelease()
    {
        if (flashlight != null)
        {
            lightOn = false;
            flashlight.SetActive(false);
        }
    }

    private void OnLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();

        aimDirection = new Vector3(lookVector.x, 0f, lookVector.y);
    }

    private void OnMouseLook(InputValue lookValue)
    {
        Vector2 lookVector = lookValue.Get<Vector2>();

        aimDirection = new Vector3((lookVector.x - (Screen.width / 2)), 0f, (lookVector.y - (Screen.height / 2)));
    }

    //player movement
    private void FixedUpdate()
    {
        //movement on X
        xMove = inputX * maxSpeed;

        //movement on Z but am too lazy to chance the wording.
        yMove = inputY * maxSpeed;

        Vector3 newPosition = new Vector3(xMove * speed * Time.fixedDeltaTime, 0.0f, yMove * speed * Time.fixedDeltaTime);
        transform.LookAt(newPosition + transform.position);

        _rb.velocity = new Vector3(xMove * speed, 0, yMove * speed);
    }

    //flashlight
    private void Update()
    {
        Debug.DrawLine(transform.position, transform.position + aimDirection, Color.red);
        //move and aim flashlight accordingly
        flashlight.transform.position = transform.position;
        flashlight.transform.LookAt(flashlight.transform.position + aimDirection);

        //deplete battery
        if (lightOn)
        {
            currentBattery -= batteryConsumption;
            if (currentBattery <= 0)
            {
                currentBattery = 0;
                OnRelease();
            }
        }
    }
}