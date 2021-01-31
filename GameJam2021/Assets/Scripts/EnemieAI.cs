using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieAi : MonoBehaviour
{
    public Transform Player;
    private Rigidbody rb;
    private float stunTime = 0;
    float curSpeed = 0;

    public float moveSpeed = 4;
    public float totalStun = 60;
    public float lungeMultiplier = 2;
    public float noticeDistance = 10;
    public float lungeDistance = 3;

    private bool close = false; // true when in chase of player
    private bool stun = false; // true when light is on player

    private enum StatesAI
    {
        Patrol, Chasing, Stunned
    }
    private StatesAI _currentState;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        curSpeed = moveSpeed;

        if (stun)
        {
            curSpeed = 0;
            stunTime++;

            if (stunTime >= totalStun)
            {
                stun = false;
            }
        }

        switch (_currentState)
        {
            case StatesAI.Chasing:
                Chasing();
                break;
            case StatesAI.Patrol:
                Patrol();
                break;
        }
    }

    private void Patrol()
    {

    }

    private void Chasing()
    {
        transform.LookAt(Player);
        if (Vector3.Distance(transform.position, Player.position) <= lungeDistance)
        {
            curSpeed = curSpeed * lungeMultiplier;//lunge or somethin
        }

        if (Vector3.Distance(transform.position, Player.position) <= noticeDistance)
        {
            rb.velocity = (transform.forward * curSpeed);
        }
        else
        {
            _currentState = StatesAI.Patrol;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.DrawLine(transform.position, Player.position, Color.red);
        
        if (other.tag == "LightStun")
        {
            var allButTriggers = ~(1 << 8);
            if (!Physics.Linecast(transform.position, Player.position, allButTriggers))
            {
                stunTime = 0;
                this.stun = true;
            }
        }
    }
}
