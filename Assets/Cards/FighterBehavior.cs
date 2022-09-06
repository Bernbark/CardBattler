using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FighterBehavior : MonoBehaviour
{
    [SerializeField] FighterCard _base;
    [SerializeField] int level;

    public Fighter Fighter { get; set; }

    public void Setup(FighterCard _base)
    {
        Fighter = new Fighter(_base, level);
        
    }
}
