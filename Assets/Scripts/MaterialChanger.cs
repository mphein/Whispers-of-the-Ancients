using UnityEngine;
using System.Collections;
//code help from chatgpt Madelyn S
public class MaterialChanger : MonoBehaviour
{
    public GameObject[] objectsToChange;
    public Material[] materials;
    public Material defaultMaterial;
    public ParticleSystem[] particleSystemsToChange;
    public Color[] particleColors;
    public float changeInterval = 5f;
    public float materialChangeDuration = 2f;

    private void Start()
    {
        // Set the default material for all objects
        foreach (GameObject obj in objectsToChange)
        {
            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null && defaultMaterial != null)
            {
                renderer.material = defaultMaterial;
            }
        }

        StartCoroutine(ChangeMaterialAndColorRoutine());
    }

    IEnumerator ChangeMaterialAndColorRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            // Randomly choose one of the game objects
            int randomIndex = Random.Range(0, objectsToChange.Length);
            GameObject selectedObject = objectsToChange[randomIndex];

            // Change its material
            Renderer renderer = selectedObject.GetComponent<Renderer>();
            if (renderer != null && materials.Length > 0)
            {
                Material newMaterial = materials[Random.Range(0, materials.Length)];
                renderer.material = newMaterial;

                // Wait for the specified duration before reverting back to the default material
                yield return new WaitForSeconds(materialChangeDuration);

                // Revert back to the default material
                renderer.material = defaultMaterial;
            }

            // Change particle colors
            foreach (ParticleSystem particleSystem in particleSystemsToChange)
            {
                var mainModule = particleSystem.main;
                if (particleColors.Length > 0)
                {
                    Color newColor = particleColors[Random.Range(0, particleColors.Length)];
                    mainModule.startColor = newColor;
                }
            }
        }
    }
}