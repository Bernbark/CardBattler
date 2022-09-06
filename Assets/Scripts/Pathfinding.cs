using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;
    
    public int waypointIndex = 0;

    public bool moveAllowed = true;

    private RandomEncounter encounter;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = waypoints[waypointIndex].transform.position;
        // Won't work on turn 1 without this, initialize the character position and then update the index so we know to advance to the next point
        waypointIndex++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public IEnumerator Move(int numberOfSpaces)
    {
        Debug.Log(numberOfSpaces);
        for(int i = 0; i < numberOfSpaces; i++)
        {
            if (waypointIndex <= waypoints.Length - 1)
            {
                transform.position = Vector2.MoveTowards(transform.position,
                    waypoints[waypointIndex].transform.position,
                    moveSpeed * Time.deltaTime);

                if (transform.position == waypoints[waypointIndex].transform.position)
                {
                    waypointIndex += 1;
                }

            }
            if (waypointIndex > waypoints.Length - 1)
            {
                waypointIndex = 0;
            }
            yield return new WaitForSeconds(.3f);
        }
        
        moveAllowed = true;
        encounter = new RandomEncounter();
    }
}
