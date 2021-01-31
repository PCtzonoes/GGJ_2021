using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float _rotateSpeed = 1.0f;

    private float _inputX;
    private float _inputY;

    private Vector3 _direction = Vector3.zero;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        _inputY = Input.GetAxis("Mouse Y");
        _inputX = Input.GetAxis("Mouse X");
    }

    private void LateUpdate()
    {
        var input = new Vector3(_inputX, transform.position.y, _inputY);
        _direction = Vector3.Lerp(_direction, input, _rotateSpeed);
        transform.LookAt(_direction);
    }
}
