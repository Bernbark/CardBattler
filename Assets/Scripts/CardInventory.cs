using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Class which holds a reference to the player's card inventory
 */
public class CardInventory : MonoBehaviour
{
    private static CardInventory _instance;
    private bool choiceMade = false;

    public static CardInventory Instance { get { return _instance; } }
    [SerializeField] public List<FighterCard> cards;
    public List<GameObject> cardSlots;
    public GameObject cardPrefab;
    public GameObject newCardPanelSelectPrefab;
    private Button button1;
    private Button button2;
    private Button button3;
    private Button button4;
    private GameObject cardPanel;
    private GameObject newCard;

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
        
        cards = new List<FighterCard>();
        
    }

    /**
     * Add card to inventory if it does not exist yet, otherwise powerup original card., if inventory is full, we need to go to a
     * "deck view" and give the user a choice to get rid of a card for the new one or to get rid of the new card.
     */
    public void AddCardToInventory(FighterCard card)
    {
        if (cards.Count >= 3)
        {
            if (cards.Contains(card))
            {
                DuplicateCardBonus(card);
            }
            else
            {
                cardPanel = Instantiate(newCardPanelSelectPrefab);
                cardPanel.transform.SetParent(BattleSystem.Instance.GetBattleSystemTransform(), false);
                cardPanel.transform.SetAsLastSibling();

                button1 = cardPanel.transform.Find("ButtonHolder").transform.Find("RemoveFirstCardButton").GetComponent<Button>();
                button2 = cardPanel.transform.Find("ButtonHolder").transform.Find("RemoveSecondCardButton").GetComponent<Button>();
                button3 = cardPanel.transform.Find("ButtonHolder").transform.Find("RemoveThirdCardButton").GetComponent<Button>();
                button4 = cardPanel.transform.Find("ButtonHolder").transform.Find("DiscardNewCardButton").GetComponent<Button>();

                button1.onClick.AddListener(() => RemoveFirstCard(card));
                button2.onClick.AddListener(() => RemoveSecondCard(card));
                button3.onClick.AddListener(() => RemoveThirdCard(card));
                button4.onClick.AddListener(DestroyPanel);


                Debug.Log("You must choose to keep your current team or discard one to keep " + card);
                GameObject cardOne = Instantiate(cardPrefab);
                FighterBehavior fighter = cardOne.GetComponent<FighterBehavior>();
                BattleHUD cardHUD = cardOne.GetComponentInChildren<BattleHUD>();
                fighter.Setup((FighterCard)CardInventory.Instance.cards[0]);
                cardHUD.SetData(fighter.Fighter);
                cardOne.transform.SetParent(cardPanel.transform.Find("WorldFighterHolder"), false);
                cardOne.transform.localPosition = cardPanel.transform.Find("ButtonHolder").transform.Find("RemoveFirstCardButton").localPosition;
                cardOne.transform.SetAsFirstSibling();

                GameObject cardTwo = Instantiate(cardPrefab);
                fighter = cardTwo.GetComponent<FighterBehavior>();
                cardHUD = cardTwo.GetComponentInChildren<BattleHUD>();
                fighter.Setup((FighterCard)CardInventory.Instance.cards[1]);
                cardHUD.SetData(fighter.Fighter);
                cardTwo.transform.SetParent(cardPanel.transform.Find("WorldFighterHolder"), false);
                cardTwo.transform.localPosition = cardPanel.transform.Find("ButtonHolder").transform.Find("RemoveSecondCardButton").localPosition;
                cardTwo.transform.SetAsFirstSibling();

                GameObject cardThree = Instantiate(cardPrefab);
                fighter = cardThree.GetComponent<FighterBehavior>();
                cardHUD = cardThree.GetComponentInChildren<BattleHUD>();
                fighter.Setup((FighterCard)CardInventory.Instance.cards[2]);
                cardHUD.SetData(fighter.Fighter);
                cardThree.transform.SetParent(cardPanel.transform.Find("WorldFighterHolder"), false);
                cardThree.transform.localPosition = cardPanel.transform.Find("ButtonHolder").transform.Find("RemoveThirdCardButton").localPosition;
                cardThree.transform.SetAsFirstSibling();

                newCard = Instantiate(cardPrefab);
                fighter = newCard.GetComponent<FighterBehavior>();
                cardHUD = newCard.GetComponentInChildren<BattleHUD>();
                fighter.Setup(card);
                cardHUD.SetData(fighter.Fighter);
                newCard.transform.SetParent(cardPanel.transform.Find("WorldFighterHolder"), false);
                newCard.transform.localPosition = cardPanel.transform.Find("ButtonHolder").transform.Find("DiscardNewCardButton").localPosition;
                newCard.transform.SetAsFirstSibling();
                

                StartCoroutine(WaitForChoice());
                choiceMade = false;
                
                BattleSystem.Instance.SetupBattle();
            }
        }
        else if (!cards.Contains(card))
        {
            cards.Add(card);

        }
        else
        {
            DuplicateCardBonus(card);
        }
    }

    IEnumerator WaitForChoice()
    {
        while (!choiceMade)
        {
            yield return null;
        }
        
        
    }

    public void DuplicateCardBonus(FighterCard card)
    {

        int index = cards.IndexOf(card);
        card = cards[index];
        card.Exp++;
        Debug.Log("Duplicated earned, gaining xp, new xp is " + cards[index].Exp);
        if (card.Exp >= 3)
        {
            card.Level++;
            card.Exp = 0;
            Debug.Log("Level Up! New level is " + cards[index].Level);
        }
        cards[index] = card;
        
    }

    public void RemoveFirstCard(FighterCard card)
    {
        cards[0].Level = 1;
        cards[0].Exp = 0;
        cards[0] = card;
        choiceMade = true;
        DestroyPanel();
        BattleSystem.Instance.SetupBattle();
    }
    public void RemoveSecondCard(FighterCard card)
    {
        cards[1].Level = 1;
        cards[1].Exp = 0;
        cards[1] = card;
        choiceMade = true;
        DestroyPanel();
        BattleSystem.Instance.SetupBattle();
    }
    public void RemoveThirdCard(FighterCard card)
    {
        cards[2].Level = 1;
        cards[2].Exp = 0;
        cards[2] = card;
        choiceMade = true;
        DestroyPanel();
        BattleSystem.Instance.SetupBattle();
    }

    public void DestroyPanel()
    {
        Destroy(cardPanel.gameObject);
        
    }
}
