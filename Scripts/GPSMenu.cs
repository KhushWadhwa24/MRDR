using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSMenu : MonoBehaviour
{
    public GameObject[] locationButtons; // Array of location buttons to toggle

    private bool areVisible = false; // Tracks visibility state

    void Start()
    {
        // Hide all location buttons initially
        foreach (GameObject button in locationButtons)
        {
            button.SetActive(false);
        }

    }

    public void ToggleLocationButtons()
    {
        areVisible = !areVisible;

        if (areVisible) { 
            Debug.Log("on"); 
        }

        if (!areVisible) { 
            Debug.Log("off"); 
        }

        // Toggle visibility of each location button
        foreach (GameObject button in locationButtons)
        {
            button.SetActive(areVisible);
        }
    }
}
