using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Makes new enemys and stores their battle card information
 */
public class EnemyBehavior : MonoBehaviour
{
    private static EnemyBehavior _instance;

    public Enemy enemy;

    public List<GameObject> activeCards;
    public GameObject cardPrefab;
    public List<GameObject> enemyCardSlots;

    public static EnemyBehavior Instance { get { return _instance; } }

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateEnemy()
    {
        enemy = new Enemy();
        activeCards = new List<GameObject>();
        List<FighterCard> fighterCard = enemy.GetFighterCards();
        for (int i = 0; i < CardInventory.Instance.cards.Count; i++)
        {
            Debug.Log("reached here fightercard count is " + fighterCard.Count);
            GameObject card = Instantiate(cardPrefab);
            //card.transform.localScale = new Vector3(1f, 1f, 1f);
            card.transform.SetParent(this.gameObject.transform, false);
            activeCards.Add(card);
            FighterBehavior fighter = activeCards[i].GetComponent<FighterBehavior>();
            BattleHUD cardHUD = activeCards[i].GetComponentInChildren<BattleHUD>();
            fighter.Setup(fighterCard[i]);
            cardHUD.SetData(fighter.Fighter);
            activeCards[i].transform.position = enemyCardSlots[i].transform.position;
        }

    }
}
