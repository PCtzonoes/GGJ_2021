using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ExitOpenHandler();

public class GameManager : MonoBehaviour
{
    public static event ExitOpenHandler ExitOpen;

    [SerializeField]
    private int _gameObjectives = 3;

    private PlayerControl _playerControl;
    private HudController _hudController;
    private Inventory _inventory;
    private Exit _exit;

    // Use for pause
    private bool isGameActive = true;

    private void Start()
    {
        // Player Controller
        _playerControl = FindObjectOfType<PlayerControl>();

        // Hud Controller
        _hudController = FindObjectOfType<HudController>();
        _hudController.UpdateCircuits(_gameObjectives);

        Debug.Log(_playerControl.currentBattery);
        _hudController.UpdateBatteryLife((int)_playerControl.currentBattery);
        StartCoroutine(UpdateBatteryHud());

        // Add Inventory
        _inventory = FindObjectOfType<Inventory>();
        Inventory.OnPickUp += Inventory_OnPickUp;

        // Add Exit
        _exit = FindObjectOfType<Exit>();
        _exit.LevelFinish += _exit_LevelFinish;

        // Level Objectives
        _gameObjectives = GameObject.FindGameObjectsWithTag("Circuit").Length;
    }

    IEnumerator UpdateBatteryHud()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(1);
            _hudController.UpdateBatteryLife((int)_playerControl.currentBattery);
        }
    }

    private void _exit_LevelFinish()
    {
        Debug.Log("Level is done");
        // TODO: Call Render new scene here object here
    }

    private void Inventory_OnPickUp(ItemSO item)
    {
        switch (item.Type)
        {
            case ItemSO.ItemType.Circuit:
                Debug.Log("Picked up Circuit");
                _gameObjectives--;
                _hudController.UpdateCircuits(_gameObjectives);
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

    private void Update()
    {
        CheckObjective();
    }

    private void CheckObjective()
    {
        if (_gameObjectives == 0)
        {
            Debug.Log("Level Finished!");
            _exit.active = true;

            // Probably call ui to display Exit has opened
            ExitOpen?.Invoke();
        }
    }
}
