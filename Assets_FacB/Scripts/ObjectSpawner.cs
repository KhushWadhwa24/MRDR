using Unity.XR.CoreUtils;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private XROrigin xrOrigin; // Reference to the XROrigin
    public GameObject objectToSpawn; // Reference to the object prefab to spawn
    public float minSpawnDistance = 0.5f; // Minimum distance from the user
    public float maxSpawnDistance = 3.0f; // Maximum distance from the user
    public float spawnHeight = 0.1f; // Height at which the object spawns above the ground

    void Start()
    {
        // Automatically find the XROrigin in the scene
        xrOrigin = FindObjectOfType<XROrigin>();

        if (xrOrigin == null)
        {
            Debug.LogError("XROrigin not found! Make sure an XROrigin is present in the scene.");
            return;
        }

        // Spawn objects randomly around the user at the start of the game
        for (int i = 0; i < 5; i++) // Spawn multiple objects for testing
        {
            SpawnObjectAtRandomPosition();
        }
    }

    void SpawnObjectAtRandomPosition()
    {
        if (xrOrigin == null) return; // Ensure XROrigin is found before proceeding

        // Calculate a random spawn position
        Vector3 randomPosition = GetRandomPositionAroundUser();
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
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
