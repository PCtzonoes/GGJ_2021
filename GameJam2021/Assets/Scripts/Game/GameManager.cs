using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int _gameObjectives = 3;

    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        Inventory.OnPickUp += Inventory_OnPickUp;
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
        }
    }
}
