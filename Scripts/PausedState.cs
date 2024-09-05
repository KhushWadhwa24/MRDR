using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PausedState : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    float tot = ScoreSystem.totalTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "" + ScoreSystem.score.ToString("F0");

        timeText.text = "Time Left: " + Mathf.Max(tot - ScoreSystem.elapsedTime, 0f).ToString("F0");
    }
}
