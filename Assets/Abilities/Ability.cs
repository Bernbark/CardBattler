using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability { 
    public AbilityBase Base { get; set; }
    public int Power { get; set; }

    public Ability(AbilityBase _base)
    {
        Base = _base;
    }
}
