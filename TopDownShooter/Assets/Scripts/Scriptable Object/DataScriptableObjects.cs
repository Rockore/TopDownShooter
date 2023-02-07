using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataScriptableObjects : ScriptableObject
{
    private List<GameObject> _weaponList = new List<GameObject>();
    private int _playerMoney;

    public List<GameObject> WeaponList
    {
        get { return _weaponList; }
        set { _weaponList = value; }
    }

    public int PlayerMoney
    {
        get { return _playerMoney; }
        set { _playerMoney = value; }
    }
}
