using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter {
    FighterCard card;
    int level;

    public List<Ability> Abilities { get; set; }
    public Fighter(FighterCard card, int level)
    {
        this.card = card;
        this.level = card.Level;

        Abilities = new List<Ability>();

        foreach(var move in card.LearnableMoves)
        {
            if (move.Level <= level)
            {
                Abilities.Add(new Ability(move.Base));
            }
            if (Abilities.Count >= 4)
            {
                break;
            }
        }
    }

    /**
     * Fecthing the information like stats from the scriptable object card to apply it to game objects
     */

    public int Attack
    {
        get { return Mathf.FloorToInt(card.Attack * level); }

    }

    public int Speed
    {
        get { return Mathf.FloorToInt(card.Speed * level); }
    }

    public int Health
    {
        get { return Mathf.FloorToInt(card.Health * level); }
        set { Health = value; }
        
    }

    public int Defense
    {
        get { return Mathf.FloorToInt(card.Defense * level); }
    }

    public string Name
    {
        get { return card.Name; }
    }

    public string Description
    {
        get { return card.Description; }
    }

    public int Experience {
        get { return card.Exp; }
    }

    public FighterCard Card
    {
        get { return card; }
    }
}
