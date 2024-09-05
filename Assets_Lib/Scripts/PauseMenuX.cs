using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuX : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameScreen;
    public GameObject GameOver;
    public bool Paused;

    void Start()
    {
        GameScreen.SetActive(true);
        PauseMenu.SetActive(false);
        GameOver.SetActive(false);
        Paused = false;
    }

    void Update()
    {
        
        if (Time1.timeLeft < 0)
        {
            gameOver();
        }
        
    }

    public void pausegame() 
    {
        GameScreen.SetActive(false);
        PauseMenu.SetActive(true);
        GameOver.SetActive(false);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void resumegame() 
    {
        GameScreen.SetActive(true);
        PauseMenu.SetActive(false);
        GameOver.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    public void quit() {
        Debug.Log("hi!");
    }

    public void Retry()
    {
        SceneManager.LoadScene("LibraryGame");
        Time.timeScale = 1f;
    }

    public void gameOver()
    {
        Time1.timeLeft = 30f;

        GameOver.SetActive(true);
        GameScreen.SetActive(false);
        PauseMenu.SetActive(false);
        Time.timeScale = 0f;
        Paused = true;
    }
}

