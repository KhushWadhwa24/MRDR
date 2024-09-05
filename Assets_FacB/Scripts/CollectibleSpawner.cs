using Unity.XR.CoreUtils;
using UnityEngine;
using System.Collections;

public class CollectibleSpawner : MonoBehaviour
{
    private XROrigin xrOrigin;
    public GameObject objectToSpawn;
    public float minSpawnDistance = 0.5f;
    public float maxSpawnDistance = 3.0f;
    public float spawnHeight = 0.1f; // Height at which the object spawns above the ground
    public float initialDelay = 15.0f; // Initial delay before starting spawning
    public float spawnInterval = 15.0f; // Interval in seconds to spawn a new collectible

    private PointToNearestCollectible arrowController; // Reference to the script that controls the arrow

    void Start()
    {
        // Automatically find the XROrigin in the scene
        xrOrigin = FindObjectOfType<XROrigin>();

        if (xrOrigin == null)
        {
            Debug.LogError("XROrigin not found! Make sure an XROrigin is present in the scene.");
            return;
        }

        // Find the PointToNearestCollectible script in the scene
        arrowController = FindObjectOfType<PointToNearestCollectible>();

        if (arrowController == null)
        {
            Debug.LogError("PointToNearestCollectible script not found! Make sure it's present in the scene.");
        }

        // Start the spawning coroutine with an initial delay
        StartCoroutine(SpawnCollectiblesWithDelay());
    }

    IEnumerator SpawnCollectiblesWithDelay()
    {
        // Wait for the initial delay before starting spawning
        yield return new WaitForSeconds(initialDelay);

        // Spawn objects initially
        for (int i = 0; i < 3; i++) // Spawn multiple objects initially for testing
        {
            SpawnObjectAtRandomPosition();
        }

        // Start the spawning loop
        while (true)
        {
            SpawnObjectAtRandomPosition();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnObjectAtRandomPosition()
    {
        if (xrOrigin == null) return; // Ensure XROrigin is found before proceeding

        // Calculate a random spawn position
        Vector3 randomPosition = GetRandomPositionAroundUser();
        GameObject spawnedObject = Instantiate(objectToSpawn, randomPosition, Quaternion.identity);

        // Add a CapsuleCollider to the spawned object if it doesn't have one
        CapsuleCollider collider = spawnedObject.GetComponent<CapsuleCollider>();
        if (collider == null)
        {
            collider = spawnedObject.AddComponent<CapsuleCollider>();
            collider.isTrigger = true; // Set the collider to be a trigger for collection
        }

        // Add a Collectible script to the spawned object
        Collectible collectibleScript = spawnedObject.AddComponent<Collectible>();

       
    }

    Vector3 GetRandomPositionAroundUser()
    {
        // Calculate a random direction on a horizontal plane
        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        // Randomize the distance within the specified range
        float randomDistance = Random.Range(minSpawnDistance, maxSpawnDistance);

        // Calculate the position relative to the XROrigin's position
        Vector3 spawnPosition = xrOrigin.transform.position + new Vector3(randomDirection.x, 0, randomDirection.y) * randomDistance;

        // Set the spawn height
        spawnPosition.y = xrOrigin.transform.position.y + spawnHeight;

        return spawnPosition;
    }
}
