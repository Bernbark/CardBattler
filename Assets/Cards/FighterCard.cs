using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Fighter Card", menuName = "Cards/Create new Fighter")]
public class FighterCard : CardBase
{
    [SerializeField]
    int health;
    [SerializeField]
    int attack;
    [SerializeField]
    int speed;
    [SerializeField]
    int defense;
    [SerializeField]
    int level;


    [SerializeField] List<LearnableMove> learnableMoves;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public int Attack
    {
        get { return attack; }
    }

    public int Speed
    {
        get { return speed; }
    }

    public int Defense
    {
        get { return defense; }
    }

    public int Level
    {
        get { return level; }
        set { level = value; }
    }

    public List<LearnableMove> LearnableMoves
    {
        get { return learnableMoves; }
    }
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] AbilityBase abilityBase;
    [SerializeField] int level;

    public AbilityBase Base
    {
        get { return abilityBase; }
    }

    public int Level
    {
        get { return level; }
    }
}
