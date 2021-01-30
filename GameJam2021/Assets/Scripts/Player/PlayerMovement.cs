using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 6.0f;

    [SerializeField]
    private float _rotateSpeed = 1.0f;

    private float _inputX;
    private float _inputY;
    private float _horizontal;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _inputY = Input.GetAxis("Vertical");
        _inputX = Input.GetAxis("Horizontal");
        _horizontal = Input.GetAxis("Mouse X") * _rotateSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 localVelocity = new Vector3(_inputX * _moveSpeed, 0, _inputY * _moveSpeed);
        _rigidBody.velocity = transform.TransformDirection(localVelocity);
    }

    private void LateUpdate()
    {
        // rotate player based on mouse horizontal
        transform.Rotate(0, _horizontal, 0);
    }
}
