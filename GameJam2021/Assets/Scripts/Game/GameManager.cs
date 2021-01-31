using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ExitOpenHandler();

public class GameManager : MonoBehaviour
{
    public static event ExitOpenHandler ExitOpen;

    [SerializeField]
    private int _gameObjectives = 3;

    private Inventory _inventory;
    private Exit _exit;

    // Start is called before the first frame update
    void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        Inventory.OnPickUp += Inventory_OnPickUp;

        _exit = FindObjectOfType<Exit>();
        _exit.LevelFinish += _exit_LevelFinish;

        _gameObjectives = GameObject.FindGameObjectsWithTag("Circuit").Length;
    }

    private void _exit_LevelFinish()
    {
        Debug.Log("Level is done");
        // TODO: Call Render new scene here object here
    }

    private void Inventory_OnPickUp(ItemSO item)
    {
        switch(item.Type)
        {
            case ItemSO.ItemType.Circuit:
                Debug.Log("Picked up Circuit");
                _gameObjectives--;
                break;
            case ItemSO.ItemType.Cog:
                Debug.Log("Picked up Cog");
                break;
            case ItemSO.ItemType.Battery:
                Debug.Log("Picked up Battery");
                break;
            default:
                Debug.Log("Unknown Type");
                throw new System.InvalidOperationException("Unknown type");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameObjectives == 0)
        {
            Debug.Log("Level Finished!");
            _exit.active = true;

            // Probably call ui to display Exit has opened
            ExitOpen?.Invoke(); 
        }
    }
}
