using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI; // For UI elements
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPanel; // Reference to the Game Over UI panel
    public TextMeshProUGUI gameOverText; // Reference to the Game Over text (optional)
    public Button retryButton; // Reference to the Retry button
    public Button leaveButton; // Reference to the Quit button

    private bool isGameOver = false; // Flag to check if the game is over

    void Start()
    {
        // Ensure the Game Over panel is hidden at the start
        gameOverPanel.SetActive(false);

        // Add listeners to buttons
        retryButton.onClick.AddListener(RestartGame);
        leaveButton.onClick.AddListener(LeaveGame);
    }

    void Update()
    {
        // Check for game over condition
        // This example uses PlayerHealth as a condition; adjust as needed
        if (PlayerHealth.currentHealth <= 0)// && !isGameOver)
        {
            GameOverSequence();
        }
    }

    void GameOverSequence()
    {
        isGameOver = true;
        // Show the Game Over panel
        gameOverPanel.SetActive(true);

        // Optionally update the Game Over text
        if (gameOverText != null)
        {
            gameOverText.text = "Game Over";
        }
    }

    void RestartGame()
    {
        // Reset game values
       // ResetGameValues();

        // Reload the current scene to restart the game
        SceneManager.LoadScene("Prof_Game");
        TouchToShoot.currentAmmo = 5;
    }

    void LeaveGame()
    {
        // Load the main menu scene
        //SceneManager.LoadScene("MainMenu"); // Ensure "MainMenu" is the name of your main menu scene
    }

    
}
