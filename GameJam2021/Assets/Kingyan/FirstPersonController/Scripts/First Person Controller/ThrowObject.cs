//Author: Kingyan Incorporated

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowObject : MonoBehaviour
{
    public bool canHold = true;
    [HideInInspector] public bool isHolding = false;

    [SerializeField] float throwForce = 600;
    Vector3 objectPos;
    float distance;
    AudioManager audioManager;
    GameObject item;
    Transform originalParent;
    GameObject crosshair;
    GameObject holdingHand;
    GameObject pointingHand;
    GameObject tempParent;

    void Start()
    {
        audioManager = GetComponent<AudioManager>();
        item = gameObject;
        originalParent = transform.parent;
        tempParent = GameObject.Find("PickUpGuide");
        holdingHand = GameObject.Find("holdingHand");
        pointingHand = GameObject.Find("pointingHand");
        crosshair = GameObject.Find("crosshair");

        //For some reason that I am unable to understand, all the crosshairs must be enabled at the start

        /*holdingHand.SetActive(false);
        pointingHand.SetActive(false);
        crosshair.SetActive(true);*/
        
    }

    // Update is called once per frame
    void Update()
    {

        distance = Vector3.Distance(item.transform.position, tempParent.transform.position);
        if (distance >= 1f)
        {
            isHolding = false;
        }
        //Check if isholding
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().velocity = Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            item.transform.SetParent(tempParent.transform);

            SetCrosshairState(2);

            if (Input.GetMouseButtonDown(1))
            {
                item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
                isHolding = false;
            }
        }
        else
        {
            objectPos = item.transform.position;
            item.transform.SetParent(originalParent);
            item.GetComponent<Rigidbody>().useGravity = true;
            item.transform.position = objectPos;
        }
    }

    void OnMouseDown()
    {
        if (distance <= 1f)
        {
            isHolding = true;
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().detectCollisions = true;

            audioManager.PlaySound("pickUpSound");
        }
    }
    void OnMouseUp()
    {
        isHolding = false;
    }

    void OnMouseOver()
    {
        if(distance <= 1f && !isHolding)
        {
            SetCrosshairState(3);
        }
    }

    void OnMouseExit()
    {
        SetCrosshairState(1);
    }

    void OnCollisionEnter(Collision col)
    {
        audioManager.PlaySound("collisionSound");
    }

    public void SetCrosshairState(int state)
    {
        if(crosshair != null && holdingHand != null && pointingHand != null)
        {
            switch (state)
            {
                case 1:
                    crosshair.SetActive(true);
                    holdingHand.SetActive(false);
                    pointingHand.SetActive(false);
                    break;
                case 2:
                    crosshair.SetActive(false);
                    holdingHand.SetActive(true);
                    pointingHand.SetActive(false);
                    break;
                case 3:
                    crosshair.SetActive(false);
                    holdingHand.SetActive(false);
                    pointingHand.SetActive(true);
                    break;
            }
        } else
        {
            Debug.LogWarning("Unable to find crosshairs");
        }
    }
}
