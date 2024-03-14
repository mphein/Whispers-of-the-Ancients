using UnityEngine;

public class LampColorController : MonoBehaviour
{
    public GameObject player;
    public Color playerFollowColor;

    private ParticleSystem particleSystem;
    private Color defaultColor;

    void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
        defaultColor = particleSystem.main.startColor.color;
    }

    void Update()
    {
        // Check if the enemy is following the player (you need to implement this logic)
        bool isPlayerFollowing = CheckIfPlayerIsFollowed();

        // Change color based on whether the player is being followed
        if (isPlayerFollowing)
        {
            particleSystem.startColor = playerFollowColor;
        }
        else
        {
            particleSystem.startColor = defaultColor;
        }

        bool IsPlayerBeingFollowed()
        {
            // Calculate the direction from the ancient to the player
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Perform a raycast to check for obstacles between the ancient and the player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, directionToPlayer, out hit))
            {
                // Check if the hit object is the player
                if (hit.collider.gameObject == player)
                {
                    // Player is visible, return true
                    return true;
                }
            }

            // Player is not visible, return false
            return false;
        }
    }

    

