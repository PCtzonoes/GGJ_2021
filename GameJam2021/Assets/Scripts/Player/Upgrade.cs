using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UpgradeType
{
    Flashlight, MoveSpeed
}
public class Upgrade : MonoBehaviour, IUpgradable
{
    void IUpgradable.Upgrade()
    {
        throw new System.NotImplementedException();
    }
}
