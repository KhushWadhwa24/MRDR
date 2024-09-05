using UnityEngine;

public class TriggerHealthDamage : MonoBehaviour
{
    public int damageAmount = 10; // Amount of damage to apply

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))  // Assuming projectiles have the "Projectile" tag
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            Destroy(other.gameObject); // Destroy the projectile on impact
        }
    }
}
