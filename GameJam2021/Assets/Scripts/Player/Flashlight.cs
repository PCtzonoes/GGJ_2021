using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light​​​​​))]
public class Flashlight : MonoBehaviour
{

    private Light​​​​​​​​​​​​​​​​​ _light​​​​​;

    void Awake()
    {
        _light​​​​​ = GetComponent<Light​​​​​>();
    }


}
