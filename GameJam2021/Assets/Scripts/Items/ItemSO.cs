using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class ItemSO : ScriptableObject
{
    public enum ItemType { Cog, Circuit, Battery }

    [SerializeField]
    private string _name;

    [SerializeField]
    private ItemType _type;

    [SerializeField]
    private float _power;

    [SerializeField]
    private int _value;

    public string Name { get => _name; }
    public ItemType Type { get => _type; }
    public float Power { get => _power; }
    public int Value { get => _value; }
}
