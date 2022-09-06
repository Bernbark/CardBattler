using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Enemy class is used to create a new enemy for the player to fight. Should be used 
 * in EnemyBehavior script.
 */
public class Enemy
{
    private List<FighterCard> cards;
    public Enemy()
    {
        cards = new List<FighterCard>();
        for (int i = 0; i < 3; i++)
        {
            FighterCard card = (FighterCard)Cards.cards[Random.Range(0, Cards.cards.Count)];
            cards.Add(card);
        }
    }

    public List<FighterCard> GetFighterCards()
    {
        return cards;
    }
}
