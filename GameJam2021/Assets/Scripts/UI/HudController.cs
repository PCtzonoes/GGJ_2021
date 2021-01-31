using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudController : MonoBehaviour
{
    public TextMeshProUGUI batteryLife;
    public TextMeshProUGUI circuits;

    // Start is called before the first frame update
    void Start()
    {
        batteryLife.text = "Battery: 100%";
        circuits.text = "Circuits: 99";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateBatteryLife(int batteryLifeVal)
    {
        batteryLife.text = "Battery: " + batteryLifeVal + "%";
    }

    public void UpdateCircuits(int circuitsVal)
    {
        circuits.text = "Circuits: " + circuitsVal;
    }
}
