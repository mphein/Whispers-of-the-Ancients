using UnityEngine;
using System.Collections;

public class ColorChanger : MonoBehaviour
{
    public GameObject[] objectsToChange;
    public Material[] materials;
    public Material defaultMaterial;
    public ParticleSystem[] particleSystemsToChange;
    public Color[] particleColors;
    public Color defaultParticleColor;
    public float changeInterval = 5f;
    public float changeDuration = 2f;

    private void Start()
    {
        StartCoroutine(ChangeColorRoutine());
    }

    IEnumerator ChangeColorRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            // Change color of game objects
            foreach (GameObject obj in objectsToChange)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null && materials.Length > 0)
                {
                    Material newMaterial = materials[Random.Range(0, materials.Length)];
                    renderer.material = newMaterial;
                }
            }

            // Change color of particle systems
            foreach (ParticleSystem particleSystem in particleSystemsToChange)
            {
                var mainModule = particleSystem.main;
                if (particleColors.Length > 0)
                {
                    Color newColor = particleColors[Random.Range(0, particleColors.Length)];
                    mainModule.startColor = newColor;
                }
            }

            // Wait for the specified duration before reverting back to default
            yield return new WaitForSeconds(changeDuration);

            // Revert back to default material for game objects
            foreach (GameObject obj in objectsToChange)
            {
                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null && defaultMaterial != null)
                {
                    renderer.material = defaultMaterial;
                }
            }

            // Revert back to default particle color
            foreach (ParticleSystem particleSystem in particleSystemsToChange)
            {
                var mainModule = particleSystem.main;
                mainModule.startColor = defaultParticleColor;
            }
        }
    }
}
