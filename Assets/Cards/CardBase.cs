using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : ScriptableObject
{
    [SerializeField]
    string name;
    [TextArea]
    [SerializeField]
    string description;
    [SerializeField]
    Sprite frontSprite;
    [SerializeField]
    Sprite backSprite;
    [SerializeField]
    int experience;
    [SerializeField]
    CardType cardType;

    // Make certain fields accessible 
    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public CardType Type
    {
        get { return cardType; }
    }

    public Sprite FrontSprite
    {
        get { return frontSprite; }
    }

    public Sprite BackSprite
    {
        get { return backSprite; }
    }

    public int Exp
    {
        get { return experience; }
        set { experience = value; }
    }

}



// Types of cards that can exist, for now we have fighters who fight for the player, support cards are pretty loosely defined
// as being temporary buffs, items are probably mostly going to be direct healing/damage based, stat items permanently boost stats 
public enum CardType
{
    Fighter,
    Support,
    Item,
    Stat
}
