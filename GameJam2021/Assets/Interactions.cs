using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Interactions : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Player;
    public GameObject Pile;

    void Start()
    {
        Player.CompareTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Player.GetComponent<Collider>();

        Pile.GetComponent<Collider>();

        if (Pile.tag == ("Finish"))
        {
            print("Move me");
        }

    }
}
