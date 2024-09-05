using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject GameScreen;
    public GameObject GameOver;

    public float finalgoal = 10000f;

    void Update()
    {
        if(Time1.timeLeft <= 0)
        {
            Endgame();
        }
        else if (Shooting.score >= finalgoal)
        {
            Endgame();
        }
    }

    public void Endgame()
    {
        Debug.Log("hi");
    }
}
