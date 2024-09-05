using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

public class HealthDisplay : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script
    public TextMeshProUGUI healthText; // Reference to the TextMeshProUGUI component for text display
    public Slider healthSlider; // Reference to the Slider component for bar display

    void Start()
    {
        if (playerHealth == null)
        {
            Debug.LogError("PlayerHealth reference not set in HealthDisplay.");
            return;
        }

        // Initialize UI elements
        if (healthText != null)
        {
            healthText.text = "Health: " + playerHealth.GetCurrentHealth();
        }

        if (healthSlider != null)
        {
            healthSlider.maxValue = playerHealth.maxHealth;
            healthSlider.value = playerHealth.GetCurrentHealth();
        }
    }

    void Update()
    {
        // Update UI elements
        if (healthText != null)
        {
            healthText.text = "Health: " + playerHealth.GetCurrentHealth();
        }

        if (healthSlider != null)
        {
            healthSlider.value = playerHealth.GetCurrentHealth();
        }
    }
}
