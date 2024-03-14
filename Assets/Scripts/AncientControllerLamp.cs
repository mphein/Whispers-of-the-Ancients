ususing System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AncientControllerLamp : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public LampColorController;
    // Start is called before the first frame update
    void Start()
    {
        if (lampColorController == null)
        {
            Debug.LogWarning("LampColorController not assigned to AncientControllerLamp color will not change.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
        bool isPlayerFollowing = IsPlayerBeingFollowed();


        if (lampColorController != null)
        {
            lampColorController.UpdateLampColor(isPlayerFollowing);
        }
    }

    bool IsPlayerBeingFollowed()
    {

        Vector3 directionToPlayer = player.transform.position - transform.position;


        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit))
        {

            if (hit.collider.gameObject == player)
            {

                return true;
            }
        }


        return false;
    }
}
}
