using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20f; // Speed of the projectile
    public float lifetime = 5f; // How long before the projectile is destroyed
    private Rigidbody rb;
    private Collider projectileCollider;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        projectileCollider = GetComponent<Collider>();

        if (projectileCollider == null)
        {
            Debug.LogError("Projectile does not have a Collider component!");
            return;
        }

        rb.velocity = transform.forward * speed; // Launch the projectile forward
        Destroy(gameObject, lifetime); // Destroy the projectile after a set time

        // Ignore collisions with the camera
        GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (cameraObject != null)
        {
            Collider cameraCollider = cameraObject.GetComponent<Collider>();
            if (cameraCollider != null)
            {
                Physics.IgnoreCollision(cameraCollider, projectileCollider);
            }
            else
            {
                Debug.LogError("MainCamera does not have a Collider component!");
            }
        }
        else
        {
            Debug.LogError("MainCamera not found!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Projectile hit the target!");
            Target target = collision.gameObject.GetComponent<Target>();
            if (target != null)
            {
                target.ReduceHealth(); // Reduce the target's health
            }
        }
        Destroy(gameObject); // Destroy the projectile itself
    }
}
