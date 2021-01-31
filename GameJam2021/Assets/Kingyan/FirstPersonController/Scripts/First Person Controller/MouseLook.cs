//Author: Kingyan Incorporated

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public Vector3 fpsCamPos;
    public Vector3 fpsPickUpGuidePos;
    public Vector3 tpsCamPos;
    public Vector3 tpsPickUpGuidePos;
    public bool isFps;

    float xRotation = 0f;
    GameObject pickUpGuide;

    void Start()
    {
        pickUpGuide = GameObject.Find("PickUpGuide");

        if (!isFps)
        {
            transform.localPosition = tpsCamPos;
            pickUpGuide.transform.localPosition = tpsPickUpGuidePos;
        }
        else
        {
            transform.localPosition = fpsCamPos;
            pickUpGuide.transform.localPosition = fpsPickUpGuidePos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        if (Input.GetKeyDown(KeyCode.V))
        {
            if (isFps)
            {
                transform.localPosition = tpsCamPos;
                pickUpGuide.transform.localPosition = tpsPickUpGuidePos;
                isFps = false;
            } else
            {
                transform.localPosition = fpsCamPos;
                pickUpGuide.transform.localPosition = fpsPickUpGuidePos;
                isFps = true;
            }
        }
    }
}
