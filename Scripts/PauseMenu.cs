using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pausemenu : MonoBehaviour
{
    public GameObject PauseMenuCanvas;
    public GameObject GameScreenCanvas;
    public GameObject GameOverCanvas;

    public static bool paused;

    private Vector3 mouseDownPos;
    public float offset = 0.85f;


    void Update()
    {
        if ((ScoreSystem.totalTime - ScoreSystem.elapsedTime) < 0) 
        {
            gameover();
        }
    }

    void Start()
    {
        GameScreenCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        paused = false;

        ScoreSystem.score = 0;

        ScoreSystem.totalTime = 60f;
        ScoreSystem.elapsedTime = 0f;
    }

    public void pausegame()
    {
        GameScreenCanvas.SetActive(false);
        PauseMenuCanvas.SetActive(true);
        GameOverCanvas.SetActive(false);
        Time.timeScale = 0f;
        paused = true;
    }
    public void resumegame()
    {
        GameScreenCanvas.SetActive(true);
        PauseMenuCanvas.SetActive(false);
        GameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }
    public void quit()
    {
        Debug.Log("hi!");
    }

    public void gameover()
    {   
        GameScreenCanvas.SetActive(false);
        PauseMenuCanvas.SetActive(false);
        GameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void retry()
    {
        SceneManager.LoadScene("OATGame"); // Change scene name later
    }

}