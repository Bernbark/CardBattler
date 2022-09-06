using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Abilities",menuName ="Ability/Create new ability")]
public class AbilityBase : ScriptableObject
{
    [SerializeField] string name;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] int power;

    public string Name { 
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public int Power
    {
        get { return power; }
    }
}
