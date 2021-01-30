using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform Player;
    private Rigidbody rb;

    public float MoveSpeed = 4;
    public float LungeSpeed = 2;
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
        float curSpeed = MoveSpeed;
        transform.LookAt(Player);
                if (Vector3.Distance(transform.position, Player.position) <= lungeDistance)
        {
            curSpeed = curSpeed * LungeSpeed;//lunge or somethin
            
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
}
