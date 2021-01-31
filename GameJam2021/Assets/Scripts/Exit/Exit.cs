using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void LevelFinishHandler();

public class Exit : MonoBehaviour
{
    private bool _active = false;
    public bool active
    {
        get => _active;

        set
        {
            if(value)
            {
                // TODO: Add Active State Change Here
                GetComponent<MeshRenderer>().material.color = _activeColor;
            }
            else
            {
                // TODO: Add Inactive State Here
                GetComponent<MeshRenderer>().material.color = _inactiveColor;
            }
            _active = value;
        }

    }

    private Color _activeColor = Color.green;
    private Color _inactiveColor = Color.red;
    public event LevelFinishHandler LevelFinish;

    void Start()
    {
        // TODO: Temp Inactive State change once we have object to render active
        GetComponent<MeshRenderer>().material.color = _inactiveColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_active && collision.gameObject.CompareTag("Player"))
        {
            LevelFinish();
        }
    }
}
