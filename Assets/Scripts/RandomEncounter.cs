using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEncounter { 

    public RandomEncounter()
    {
        int randomNum = Random.Range(1, 6);
        FighterCard card = (FighterCard)Cards.cards[Random.Range(0, Cards.cards.Count)];
        switch (randomNum)
        {
            case 1:
                // Player heals
                PlayerStats.Instance.Health++;
                break;
            case 2:
                CardInventory.Instance.AddCardToInventory(card);
                Debug.Log("Card added to inventory: "+card.Name);
                PlayerStats.Instance.Health--;
                BattleSystem.Instance.SetupBattle();
                break;
            case 3:
                CardInventory.Instance.AddCardToInventory(card);
                Debug.Log("Card added to inventory: " + card.Name);
                PlayerStats.Instance.Defense++;
                BattleSystem.Instance.SetupBattle();
                break;
            case 4:
                CardInventory.Instance.AddCardToInventory(card);
                Debug.Log("Card added to inventory: " + card.Name);
                BattleSystem.Instance.SetupBattle();
                break;
            default:
                CardInventory.Instance.AddCardToInventory(card);
                Debug.Log("Card added to inventory: " + card.Name);
                BattleSystem.Instance.SetupBattle();
                break;
        }
    }
}
