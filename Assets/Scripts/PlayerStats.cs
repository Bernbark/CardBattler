using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private static PlayerStats _instance;

    public static PlayerStats Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        Initialize();
    }

    public int Health;
    public int Gold;
    public int Damage;
    public int Defense;
    public int Speed;

    private void Initialize()
    {
        Health = 10;
        Gold = 0;
        Damage = 1;
        Defense = 0;
        Speed = 2;
    }
}
