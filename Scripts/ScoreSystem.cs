using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;  // Ensure this is assigned in the Inspector
    public static float elapsedTime = 0f;  // Tracks the time elapsed
    public static float totalTime = 60f;  // Total time for the countdown
    public static float timeLeft;

    public static int score=0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + score.ToString("F0");

        elapsedTime += Time.deltaTime;
        timeLeft = totalTime - elapsedTime;

        timeText.text = "" + Mathf.Max(timeLeft, 0f).ToString("F0");

    }
}
