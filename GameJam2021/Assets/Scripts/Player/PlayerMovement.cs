using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 6;

    private float _inputX;
    private float _inputY;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _inputY = Input.GetAxis("Vertical");
        _inputX = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector3(_inputX * _moveSpeed, 0, _inputY * _moveSpeed);
    }
}
