using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    public Transform player;
    public Vector3 offset;

    void LateUpdate()
    {
        // Camera follows the player with specified offset position
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
    
}
