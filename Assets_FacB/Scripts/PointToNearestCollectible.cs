using System.Collections.Generic;
using UnityEngine;

public class PointToNearestCollectible : MonoBehaviour
{
    public GameObject arrow; // Reference to the 3D arrow asset
    private Camera arCamera; // Reference to the AR Camera
    public float updateInterval = 0.5f; // How often to update the arrow direction, in seconds
    private List<GameObject> collectibles = new List<GameObject>(); // List to store all active collectibles
    private float timeSinceLastUpdate = 0f; // Timer to track the time since the last update

    void Start()
    {
        // Find the AR Camera tagged as MainCamera
        arCamera = Camera.main;

        if (arCamera == null)
        {
            Debug.LogError("AR Camera (tagged as MainCamera) not found! Make sure the AR Camera is properly tagged.");
            return;
        }
    }

    void Update()
    {
        // Update the timer
        timeSinceLastUpdate += Time.deltaTime;

        // Only update the arrow direction at the specified interval
        if (timeSinceLastUpdate >= updateInterval)
        {
            UpdateArrowDirection();
            timeSinceLastUpdate = 0f; // Reset the timer after updating
        }
    }

    void UpdateArrowDirection()
    {
        if (collectibles.Count == 0)
        {
            Debug.Log("No collectibles available to point at.");
            return;
        }

        // Find the nearest collectible
        GameObject nearestCollectible = FindNearestCollectible();

        if (nearestCollectible != null)
        {
            // Calculate direction from the AR camera to the nearest collectible
            Vector3 directionToCollectible = nearestCollectible.transform.position - arCamera.transform.position;

            // Make the arrow point in the direction of the nearest collectible
            arrow.transform.rotation = Quaternion.LookRotation(directionToCollectible);
        }
    }

    GameObject FindNearestCollectible()
    {
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject collectible in collectibles)
        {
            if (collectible != null) // Check if the collectible still exists
            {
                float distance = Vector3.Distance(arCamera.transform.position, collectible.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = collectible;
                }
            }
        }

        return nearest;
    }

    public void RegisterCollectible(GameObject collectible)
    {
        if (!collectibles.Contains(collectible))
        {
            collectibles.Add(collectible); // Add newly spawned collectibles to the list
        }
    }

    public void UnregisterCollectible(GameObject collectible)
    {
        if (collectibles.Contains(collectible))
        {
            collectibles.Remove(collectible); // Remove collected or destroyed collectibles from the list
        }
    }
}
