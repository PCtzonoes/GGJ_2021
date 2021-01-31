using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void ItemPicker(ItemSO item);

    public static event ItemPicker OnPickUp;

    private Dictionary<ItemSO, int> _items = new Dictionary<ItemSO, int>();

    public Dictionary<ItemSO, int> Items { get => _items; private set => _items = value; }

    private void AddItemToIventory(ItemSO item)
    {
        Debug.Log(item);
        if (item == null) return;

        if (Items.ContainsKey(item))
        {
            Items[item]++;
        }
        else Items.Add(item, 1);

        OnPickUp?.Invoke(item);
    }

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<IPickable>();

        if (item == null) return;

        AddItemToIventory(item.PickUp());
    }
}
