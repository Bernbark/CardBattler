using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A class designed to hold on to a list of all cards in the game. Probably needs
 * access to a database scriptable object
 */
public class Cards : MonoBehaviour
{
    [SerializeField]public static List<CardBase> cards;
    List<Fighter> fighters;
    [SerializeField] CardDatabase database;

    private void Start()
    {
        cards = new List<CardBase>();
        fighters = new List<Fighter>();
        
        // Create the initial list of all cards
        foreach (FighterCard card in database.fighterCards)
        {
            cards.Add(card);
        }
        // Change this list to be something which can adjust stats of cards without adjusting the stats of 
        // the base scriptable objects.
        for(var i = 0; i < database.fighterCards.Count; i++)
          {
              cards[i] = Instantiate(cards[i]) as FighterCard;
          }
    }
}
