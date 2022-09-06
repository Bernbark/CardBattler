using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Holds a reference to all of the text of the fighter cards in the battlefield view.
 */
public class BattleHUD : MonoBehaviour
{
    public Text hpText;
    public Text spdText;
    public Text defText;
    public Text atkText;
    public void SetData(Fighter fighter)
    {
        hpText.text = fighter.Health.ToString();
        Debug.Log(fighter.Health.ToString() + " fighter health");
        spdText.text = fighter.Speed.ToString();
        defText.text = fighter.Defense.ToString();
        atkText.text = fighter.Attack.ToString();
        GetComponentInChildren<Image>().sprite = fighter.Card.FrontSprite;
    }
}
