using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCollision : MonoBehaviour
{
    public PlayerMovement movemment;


     void OnCollisionEnter (Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movemment.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}

