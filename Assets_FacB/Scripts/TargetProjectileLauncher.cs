using UnityEngine;

public class TargetProjectileLauncher : MonoBehaviour
{
    public bool canCollide = true;
    public GameObject projectilePrefab;
    public float projectileSpeed = 20f;
    public float fireRate = 2f;
    public float lifeTime = 6f;
    public float initialDelay = 2f; // Delay before the first projectile is fired
    public Vector3 offset;
    public float angle = 110f;

    private Transform playerTransform;

    void Start()
    {
        // Find the player object tagged as "MainCamera"
        GameObject player = GameObject.FindGameObjectWithTag("MainCamera");
        if (player != null)
        {
            playerTransform = player.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'MainCamera' not found!");
        }

        // Start firing projectiles after the initial delay
        if (playerTransform != null)
        {
            Invoke("StartFiring", initialDelay); // Call StartFiring after the initial delay
        }
    }

    void StartFiring()
    {
        // Start firing projectiles at the specified rate
        if (playerTransform != null)
        {
            InvokeRepeating("FireProjectile", 0f, fireRate);
        }
    }

    void FireProjectile()
    {
        if (projectilePrefab == null || playerTransform == null) return;

        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, transform.position + offset, Quaternion.identity);
        canCollide = true;
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true; // Disable gravity

            // Calculate direction towards the player
            Vector3 direction = (playerTransform.position - transform.position).normalized;

            float firingAngle = angle;
            Vector3 rotationAxiz = Vector3.up;
            Quaternion rotationOffset = Quaternion.AngleAxis(firingAngle, rotationAxiz);
            Vector3 adjustedDirection = rotationOffset * direction;

            projectile.transform.rotation = Quaternion.LookRotation(adjustedDirection);

            rb.velocity = adjustedDirection * projectileSpeed;

            
            Debug.Log("Projectile fired towards " + playerTransform.position + " with adjustedDirection");

            Destroy(projectile, lifeTime);
        }
        else
        {
            Debug.LogError("Projectile prefab does not have a Rigidbody component!");
        }
    }
}
