using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } // Singleton instance
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        // Ensure there is only one instance of GameManager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist GameManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void GameOver()
    {
        // Logic for ending the game (e.g., showing a game over screen or reloading the scene)
        Debug.Log("Game Over!");
        gameOverPanel.SetActive(true);
    }
}
