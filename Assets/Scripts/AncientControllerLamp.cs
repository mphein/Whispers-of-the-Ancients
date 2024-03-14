using UnityEngine;
using UnityEngine.AI;

public class AncientControllerLamp : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public LampColorController lampColorController; // Reference to the lamp's color controller

    void Update()
    {
        // Check if agent and player references are not null before using them
    if (agent == null || player == null)
    {
        return;
    }
// Set destination to the player
        agent.SetDestination(player.transform.position);

        // Check if the player is in sight
        bool isPlayerInSight = CheckIfPlayerIsInSight();

        // Update lamp color based on whether the player is in sight
        if (lampColorController != null)
        {
            lampColorController.UpdateLampColor(isPlayerInSight);
        }

    }

    bool CheckIfPlayerIsInSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, player.transform.position - transform.position, out hit))
        {
            // Check if the hit object is the player
            if (hit.collider.gameObject == player)
            {
                return true; // Player is in sight
            }
        }
        return false; // Player is not in sight
    }
}


