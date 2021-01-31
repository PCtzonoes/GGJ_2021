﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class EnemieAI : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody rb;
    private float stunTime = 0;
    float curSpeed = 0;

    public float moveSpeed = 4;
    public float totalStun = 60;
    public float lungeMultiplier = 2;
    public float noticeDistance = 10;
    public float lungeDistance = 3;
    [SerializeField]
    private float _patrollingSpeed = 0.5f;

    private bool close = false; // true when in chase of player.transform
    private bool stun = false; // true when light is on player.transform

    [SerializeField]
    private Transform[] _patrolPositions;

    private int _currentPatrolPosition = 0;

    public enum StatesAI
    {
        Patrol, Chasing, Stunned
    }
    private StatesAI _currentState = StatesAI.Patrol;

    public StatesAI CurrentState { get => _currentState; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        if (_patrolPositions == null)
        {
            Debug.LogWarning($"No Patrol Positions in :{gameObject.name}");
            Destroy(gameObject);
        }
    }

    internal void PlayerFound()
    {
        if (_currentState != StatesAI.Stunned) _currentState = StatesAI.Chasing;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        curSpeed = moveSpeed;

        switch (_currentState)
        {
            case StatesAI.Chasing:
                Chasing();
                break;
            case StatesAI.Patrol:
                Patrol();
                break;
            case StatesAI.Stunned:
                Stunned();
                break;
        }
    }

    private void Stunned()
    {
        if (stun)
        {
            curSpeed = 0;
            stunTime++;

            if (stunTime >= totalStun)
            {
                stun = false;
                _currentState = StatesAI.Patrol;
            }
        }
    }

    private void Patrol()
    {
        MoveTo();
    }

    private void MoveTo()
    {
        if ((transform.position - _patrolPositions[_currentPatrolPosition].position).magnitude > 0.15f)
        {
            transform.LookAt(_patrolPositions[_currentPatrolPosition].position);
            curSpeed *= _patrollingSpeed;
            rb.velocity = (transform.forward * curSpeed);
        }
        else
        {
            _currentPatrolPosition++;
            _currentPatrolPosition %= _patrolPositions.Length;
        }
    }

    private void Chasing()
    {
        transform.LookAt(Player.transform);
        if (Vector3.Distance(transform.position, Player.transform.position) <= lungeDistance)
        {
            curSpeed = curSpeed * lungeMultiplier;//lunge or somethin
        }

        if (Vector3.Distance(transform.position, Player.transform.position) <= noticeDistance)
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
        Debug.DrawLine(transform.position, Player.transform.position, Color.red);

        if (other.tag == "LightStun")
        {
            var allButTriggers = ~(1 << 8);
            if (!Physics.Linecast(transform.position, Player.transform.position, allButTriggers))
            {
                stunTime = 0;
                this.stun = true;
                _currentState = StatesAI.Stunned;
            }
        }
    }
}