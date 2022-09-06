using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

/**
 * Handles the world card behavior such as placing the owner's and enemy's cards on the field, and controls systems
 * which handle fighting, keeps a list of active cards as well.
 */
public class BattleSystem : MonoBehaviour
{
    private static BattleSystem _instance;
    [SerializeField] FighterBehavior playerUnit;
    [SerializeField] BattleHUD playerHud;
    public GameObject cardPrefab;
    public Canvas battleCanvas;
    public List<GameObject> activeCards;
    public Button fightButton;

    public static BattleSystem Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

    }

    private void Start()
    {
        activeCards = new List<GameObject>();
        fightButton.onClick.AddListener(Fight);
        SetupBattle();
    }

    public Transform GetBattleSystemTransform()
    {
        return GameObject.Find("BattleCanvas").transform;
    }

    /**
     * Sets up the battle, if active cards hold cards currently then get rid of them as well as their gameObjects,
     * then, for every item in the inventory, place it in an appropriate spot on the battlefield.
     */
    public void SetupBattle()
    {
        if (activeCards.Count > 0)
        {
            for (int i = 0; i < activeCards.Count; i++)
            {
                Destroy(activeCards[i].gameObject);
            }
        }
        activeCards.Clear();
        for (int i = 0; i < CardInventory.Instance.cards.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("FighterHolder").transform);
            card.transform.localScale = new Vector3(1f, 1f, 1f);
            activeCards.Add(card);
            FighterBehavior fighter = activeCards[i].GetComponent<FighterBehavior>();
            BattleHUD cardHUD = activeCards[i].GetComponentInChildren<BattleHUD>();
            fighter.Setup((FighterCard)CardInventory.Instance.cards[i]);
            cardHUD.SetData(fighter.Fighter);
            //activeCards[i].transform.SetParent(battleCanvas.transform, false);
            activeCards[i].transform.position = CardInventory.Instance.cardSlots[i].transform.position;
            
        }
        EnemyBehavior.Instance.CreateEnemy();
        //playerUnit.Setup();
        //playerHud.SetData(playerUnit.Fighter);
    }

    public void Fight()
    {
        List<FighterCard> fighterCards = EnemyBehavior.Instance.enemy.GetFighterCards();
        for (int i = 0; i < activeCards.Count; i++)
        {
            int realDmg = CardInventory.Instance.cards[i].Attack - fighterCards[i].Defense;
            if(realDmg <= 0)
            {
                realDmg = 1;
            }
            
            fighterCards[i].Health -= realDmg;
            Debug.Log("enemy " + fighterCards[i].Name + " took " + realDmg + " damage");

            realDmg = fighterCards[i].Attack- CardInventory.Instance.cards[i].Defense;
            if (realDmg <= 0)
            {
                realDmg = 1;
            }
            CardInventory.Instance.cards[i].Health -= realDmg;
            Debug.Log("your card " + CardInventory.Instance.cards[i].Name + " took " + realDmg + " damage");

            FighterBehavior fighter = activeCards[i].GetComponent<FighterBehavior>();
            BattleHUD cardHUD = activeCards[i].GetComponentInChildren<BattleHUD>();
            fighter.Setup((FighterCard)CardInventory.Instance.cards[i]);
            cardHUD.SetData(fighter.Fighter);

            fighter = EnemyBehavior.Instance.activeCards[i].GetComponentInChildren<FighterBehavior>();
            cardHUD = EnemyBehavior.Instance.activeCards[i].GetComponentInChildren<BattleHUD>();
            fighter.Setup((FighterCard)fighterCards[i]);
            cardHUD.SetData(fighter.Fighter);

            if (CardInventory.Instance.cards[i].Health <= 0)
            {
                
                Destroy(activeCards[i].gameObject);
                
                CardInventory.Instance.cards.Remove(CardInventory.Instance.cards.ElementAt(i));
                activeCards.Remove(activeCards.ElementAt(i));
            }
            if (fighterCards[i].Health <= 0)
            {
                Destroy(EnemyBehavior.Instance.activeCards[i].gameObject);
                //EnemyBehavior.Instance.activeCards[i] = null;
            }
        }
    }

    public void DecideOrder(int i)
    {
        if(i == 0)
        {
            activeCards[0] = activeCards[1];
            activeCards[1] = activeCards[2];
        }
        else if (i == 1)
        {

        }
        else
        {

        }
    }
}
