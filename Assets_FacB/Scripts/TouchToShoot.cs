using UnityEngine;

public class TouchToShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Reference to the projectile prefab
    private Camera arCamera; // Reference to the AR Camera
    public float projectileSpeed = 10f; // Speed of the projectile
    public float spawnDistance = 3f; // Distance in front of the camera to spawn the projectile
    public static int currentAmmo = 5;
    void Start()
    {
        // Automatically find the AR Camera tagged as "MainCamera"
        arCamera = Camera.main;

        if (arCamera == null)
        {
            Debug.LogError("AR Camera (Main Camera) not found! Make sure it is tagged as 'MainCamera'.");
        }
    }
    
    void Update()
    {
        // Check if the screen was touched
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // Get touch position
            if (currentAmmo > 0)
            {
                Vector2 touchPosition = Input.GetTouch(0).position;

                // Convert touch position to a ray from the camera
                Ray ray = arCamera.ScreenPointToRay(touchPosition);

                // Set target position using the ray direction and a spawn distance from the camera
                Vector3 targetPosition = ray.origin + ray.direction * spawnDistance;

                // Shoot projectile towards the target position
                ShootProjectile(targetPosition);
            }
            currentAmmo--;

            if (currentAmmo < 0) 
            {
                currentAmmo = 0;
            }
        }
    }

    void ShootProjectile(Vector3 targetPosition)
    {
        if (arCamera == null) return; // Ensure required objects are assigned

        // Instantiate the projectile at the current camera position plus some offset
        GameObject projectile = Instantiate(projectilePrefab, arCamera.transform.position + arCamera.transform.forward * 0.5f, Quaternion.identity);

        // Calculate the direction from the projectile's current position to the target position
        Vector3 direction = (targetPosition - projectile.transform.position).normalized;

        // Set projectile rotation to face the target
        projectile.transform.rotation = Quaternion.LookRotation(direction);

        // Get the Rigidbody component and set velocity
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // Disable gravity

           

            // Set projectile velocity
            rb.velocity = direction * projectileSpeed;

            Debug.Log("Projectile shot towards " + targetPosition);
        }
        else
        {
            Debug.LogError("Projectile prefab does not have a Rigidbody component!");
        }
    }
}