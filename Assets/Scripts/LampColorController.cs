using UnityEngine;

public class LampColorController : MonoBehaviour
{
    public Material playerInSightMaterial; // Material when player is in sight
    public Material defaultMaterial; // Default material when player is not in sight

    public new ParticleSystem particleSystem; // Reference to the particle system

    void Start()
    {
        // Check if particleSystem is assigned
        if (particleSystem == null)
        {
            Debug.LogError("Particle System is not assigned in LampColorController.");
            return;
        }
    }

    public void UpdateLampColor(bool isPlayerInSight)
    {
        // Get materials from the particle system renderer
        var renderer = particleSystem.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogError("Renderer component not found on Particle System.");
            return;
        }

        Material[] materials = renderer.materials;

        // Change material colors based on whether the player is in sight
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = isPlayerInSight ? playerInSightMaterial.color : defaultMaterial.color;
        }
    }
}


