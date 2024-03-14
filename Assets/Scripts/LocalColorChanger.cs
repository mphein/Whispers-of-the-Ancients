using UnityEngine;

public class LocalColorChanger : MonoBehaviour
{
    public Material defaultMaterial;
    public Material alternateMaterial;
    public Color defaultParticleColor;
    public Color alternateParticleColor;
    public Color defaultLightColor;
    public Color alternateLightColor;
    public GameObject gameObjectToChange;
    public ParticleSystem particleSystemToChange;
    public Light lightToChange;

    private Material[] defaultMaterials;
    private Material[] alternateMaterials;

    private void Start()
    {
        // Store the default materials
        defaultMaterials = new Material[GetComponent<Renderer>().materials.Length];
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            defaultMaterials[i] = defaultMaterial;
        }

        // Store the alternate materials
        alternateMaterials = new Material[GetComponent<Renderer>().materials.Length];
        for (int i = 0; i < alternateMaterials.Length; i++)
        {
            alternateMaterials[i] = alternateMaterial;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Change color immediately when the enemy enters the trigger
            ChangeColor(alternateMaterial, alternateParticleColor, alternateLightColor);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Revert color immediately when the enemy exits the trigger
            ChangeColor(defaultMaterial, defaultParticleColor, defaultLightColor);
        }
    }

    private void ChangeColor(Material materialToChange, Color particleColor, Color lightColor)
    {
        // Change material color
        foreach (Renderer renderer in gameObjectToChange.GetComponentsInChildren<Renderer>())
        {
            renderer.material = materialToChange;
        }

        // Change particle color
        var mainModule = particleSystemToChange.main;
        mainModule.startColor = particleColor;

        // Change light color
        lightToChange.color = lightColor;
    }
}



