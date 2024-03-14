using UnityEngine;

public class LampTrigger : MonoBehaviour
{
    public delegate void TriggerEventHandler(GameObject lamp);
    public event TriggerEventHandler OnEnterTrigger;
    public event TriggerEventHandler OnExitTrigger;

    private SphereCollider triggerCollider; // Reference to the SphereCollider

    private void Start()
    {
        // Get the SphereCollider component
        triggerCollider = GetComponent<SphereCollider>();
        if (triggerCollider == null)
        {
            Debug.LogError("LampTrigger requires a SphereCollider component.");
            enabled = false; // Disable the script if SphereCollider is not found
        }
        else
        {
            // Ensure the SphereCollider is set as a trigger
            triggerCollider.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnEnterTrigger?.Invoke(gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            OnExitTrigger?.Invoke(gameObject);
        }
    }

    // Method to set the radius of the SphereCollider
    public void SetRadius(float radius)
    {
        if (triggerCollider != null)
        {
            triggerCollider.radius = radius;
        }
    }
}
