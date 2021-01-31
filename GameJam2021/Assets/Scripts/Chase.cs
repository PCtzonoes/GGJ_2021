using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform Player;
    private Rigidbody rb;
    private float stunTime = 0;

    public float moveSpeed = 4;
    public float totalStun = 60;
    public float lungeMultiplier = 2;
    public float noticeDistance = 10;
    public float lungeDistance = 5;

    private bool close = false; // true when in chase of player
    private bool stun = false; // true when light is on player

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    { 
        float curSpeed = moveSpeed;

        if (stun)
        {
            curSpeed = 0;
            stunTime++;

            if(stunTime >= totalStun)
            {
                stun = false;
            }
        }

        transform.LookAt(Player);
                if (Vector3.Distance(transform.position, Player.position) <= lungeDistance)
        {
            curSpeed = curSpeed * lungeMultiplier;//lunge or somethin
            
        }

        if (Vector3.Distance(transform.position, Player.position) <= noticeDistance)
        {
            //close = true;
            transform.position += (transform.forward * curSpeed * Time.deltaTime);
        }
        else
        {
            //close = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "LightStun")
        {
            stunTime = 0;
            this.stun = true;
        }
    }
}
