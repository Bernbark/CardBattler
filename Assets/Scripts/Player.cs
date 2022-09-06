using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float timeToWait = 2f;
    private int diceRoll;
    private Pathfinding pathfinding;
    // Start is called before the first frame update
    void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RollAndMove();
            StartCoroutine(WaitForRoll(timeToWait));
            
        }
    }

    public void RollAndMove()
    {
        if (pathfinding.moveAllowed)
        {
            StartCoroutine(pathfinding.Move(GameManager.Instance.Roll(6)));
            pathfinding.moveAllowed = false;
        }
        
    }

    IEnumerator WaitForRoll(float time)
    {
        yield return new WaitForSeconds(time);
    }
}
