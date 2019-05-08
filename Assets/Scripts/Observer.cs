using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;
    bool m_IsPlayerInRange;

    //Checks if the player is in range of the observer's line of sight.
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
        }
    }

    //Checks if the player has exited the observer's line of sight.
    void OnTriggerExit(Collider other)
    {
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }

    //Checks if the observer's line of sight to the player is clear.
    void Update()
    {
        if (m_IsPlayerInRange)  //player is in line of sight range
        {
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);

            RaycastHit raycastHit;

            if (Physics.Raycast(ray, out raycastHit))   //There is something in the line of sight (wall or player)
            {
                if (raycastHit.collider.transform == player)    //Line of sight to player is clear.
                {
                    //follow player? 
                }
            }
        }
    }


}
