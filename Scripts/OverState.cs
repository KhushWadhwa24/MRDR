using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OverState : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Hearts Broken: " + ScoreSystem.score.ToString("F0");

    }
}
