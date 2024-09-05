using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float collectionDistance = 0.5f;
    public int scoreValue = 1; // This will represent the ammo count
    public float lifetime = 5.0f;

    private Transform playerTransform;
    private float timer;
    

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        if (player != null)
        {
            playerTransform = player.transform;
            timer = lifetime;
        }
        else
        {
            Debug.LogError("Player with tag 'MainCamera' not found!");
        }
    }

    void Update()
    {
        if (playerTransform != null)
        {
            float distance = Vector3.Distance(playerTransform.position, transform.position);

            if (distance <= collectionDistance)
            {
                Collect();
            }
            else
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    DestroyCollectible();
                }
            }
        }
    }

    void Collect()
    {
        Debug.Log("Collectible collected!");

        // Add to the global ammo count
        TouchToShoot.currentAmmo += 1;
        Debug.Log("Current ammo: " + TouchToShoot.currentAmmo);

        Destroy(gameObject); // Remove the collectible from the scene
    }

    void DestroyCollectible()
    {
        Destroy(gameObject); // Destroy the collectible
    }
}
