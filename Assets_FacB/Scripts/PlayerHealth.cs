using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health of the player
    public static int currentHealth=3; // Current health of the player
    public TargetProjectileLauncher TPL;


    private void Start()
    {
        currentHealth = maxHealth; // Initialize the player's health to maximum at the start

        // Find the TargetProjectileLauncher component at runtime
        TPL = GameObject.FindObjectOfType<TargetProjectileLauncher>();

        if (TPL == null)
        {
            Debug.LogError("TargetProjectileLauncher component not found!");
        }
    }



    // Method to reduce the player's health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Ensure health does not go below zero
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Player is dead!");
            
            // Add any additional logic for player death here (e.g., game over screen)
        }
        else
        {
            Debug.Log("Player took damage! Current health: " + currentHealth);
        }
    }

    // Method to get the current health of the player
    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))  // Assuming the MainCamera tag is used for the player
        {
            
            
            currentHealth--;
            if (currentHealth<=0)// && TPL.canCollide)
            {
                
                TPL.canCollide = false;
                GameManager.Instance.GameOver();
                currentHealth = 0;
            }
        }
    }
}
