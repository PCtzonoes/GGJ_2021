using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IPickable
{
    [SerializeField]
    private ItemSO _itemSO;

    [SerializeField]
    private GameObject _spawnOnPickUP;

    private bool _pickOnce = false;

    private void Awake()
    {
        if (_itemSO == null)
        {
            Debug.LogWarning($"Item {gameObject.name} does not have item ScriptableObject set to it");
            Destroy(gameObject);
        }
    }

    public ItemSO PickUp()
    {
        if (_pickOnce) return null;

        _pickOnce = true;

        if (_spawnOnPickUP != null) Instantiate(_spawnOnPickUP, transform.position, Quaternion.identity);

        Destroy(gameObject);
        return _itemSO;
    }
}
