using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class allows for creation of Database SO's which can hold lists of all of the cards in the game.
 */
[CreateAssetMenu(fileName ="Card Database",menuName ="Database/Create Database for Cards")]
public class CardDatabase : ScriptableObject
{
    public List<FighterCard> fighterCards = new List<FighterCard>();

}
