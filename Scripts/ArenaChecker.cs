using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ArenaChecker : MonoBehaviour
{
    public Transform placeIndicator; // The circular plane
    public Transform oatArena; // The 2D ring
    public Transform libArena;
    public Transform facbArena;
    public Transform testArena;

    public Button oatStartButton;
    public Button libStartButton;
    public Button facbStartButton;
    public Button testStartButton;

    public float placeIndicatorRadius = 0.8f; // Radius of the place indicator circle
    public float libArenaOuterRadius = 6f; // Outer radius of the 2D ring arena
    
    // Start is called before the first frame update
    void Start()
    {
        // Initially hide the start button
        oatStartButton.gameObject.SetActive(false);
        // Add listener to the start button to switch scenes
        oatStartButton.onClick.AddListener(SwitchToOATScene);

        // Initially hide the start button
        libStartButton.gameObject.SetActive(false);
        // Add listener to the start button to switch scenes
        libStartButton.onClick.AddListener(SwitchToLibScene);

        // Initially hide the start button
        facbStartButton.gameObject.SetActive(false);
        // Add listener to the start button to switch scenes
        facbStartButton.onClick.AddListener(SwitchToFacBScene);

        // Initially hide the start button
        testStartButton.gameObject.SetActive(false);
        // Add listener to the start button to switch scenes
        testStartButton.onClick.AddListener(SwitchToTestScene);
    }

    void Update()
    {
        // Check if the place indicator is within the bounds of the game arena
        if (IsWithinOATArena())
        {
            // Show the start button
            oatStartButton.gameObject.SetActive(true);
        }
        else
        {
            // Hide the start button
            oatStartButton.gameObject.SetActive(false);
        }

        if (IsWithinLibArena())
        {
            // Show the start button
            libStartButton.gameObject.SetActive(true);
        }
        else
        {
            // Hide the start button
            libStartButton.gameObject.SetActive(false);
        }

        if (IsWithinFacBArena())
        {
            // Show the start button
            facbStartButton.gameObject.SetActive(true);
        }
        else
        {
            // Hide the start button
            facbStartButton.gameObject.SetActive(false);
        }

        if (IsWithinTestArena())
        {
            // Show the start button
            testStartButton.gameObject.SetActive(true);
        }
        else
        {
            // Hide the start button
            testStartButton.gameObject.SetActive(false);
        }
    }

    bool IsWithinOATArena()
    {
        // Get the positions of the place indicator and the arena
        Vector3 placeIndicatorPosition = placeIndicator.position;
        Vector3 libArenaPosition = oatArena.position;

        // Calculate the distance from the center of the place indicator to the center of the arena
        float distance = Vector3.Distance(new Vector3(placeIndicatorPosition.x, 0, placeIndicatorPosition.z), new Vector3(libArenaPosition.x, 0, libArenaPosition.z));

        // Check if the entire radius of the place indicator is within the outer radius of the arena
        return (distance + placeIndicatorRadius) <= libArenaOuterRadius;
    }

    bool IsWithinLibArena()
    {
        // Get the positions of the place indicator and the arena
        Vector3 placeIndicatorPosition = placeIndicator.position;
        Vector3 libArenaPosition = libArena.position;

        // Calculate the distance from the center of the place indicator to the center of the arena
        float distance = Vector3.Distance(new Vector3(placeIndicatorPosition.x, 0, placeIndicatorPosition.z), new Vector3(libArenaPosition.x, 0, libArenaPosition.z));

        // Check if the entire radius of the place indicator is within the outer radius of the arena
        return (distance + placeIndicatorRadius) <= libArenaOuterRadius;
    }

    bool IsWithinFacBArena()
    {
        // Get the positions of the place indicator and the arena
        Vector3 placeIndicatorPosition = placeIndicator.position;
        Vector3 libArenaPosition = facbArena.position;

        // Calculate the distance from the center of the place indicator to the center of the arena
        float distance = Vector3.Distance(new Vector3(placeIndicatorPosition.x, 0, placeIndicatorPosition.z), new Vector3(libArenaPosition.x, 0, libArenaPosition.z));

        // Check if the entire radius of the place indicator is within the outer radius of the arena
        return (distance + placeIndicatorRadius) <= libArenaOuterRadius;
    }

    bool IsWithinTestArena()
    {
        // Get the positions of the place indicator and the arena
        Vector3 placeIndicatorPosition = placeIndicator.position;
        Vector3 libArenaPosition = testArena.position;

        // Calculate the distance from the center of the place indicator to the center of the arena
        float distance = Vector3.Distance(new Vector3(placeIndicatorPosition.x, 0, placeIndicatorPosition.z), new Vector3(libArenaPosition.x, 0, libArenaPosition.z));

        // Check if the entire radius of the place indicator is within the outer radius of the arena
        return (distance + placeIndicatorRadius) <= libArenaOuterRadius;
    }

    void SwitchToOATScene()
    {
        // Load the game scene
        SceneManager.LoadScene(3);
    }

    void SwitchToLibScene()
    {
        // Load the game scene
        SceneManager.LoadScene(4);
    }

    void SwitchToFacBScene()
    {
        // Load the game scene
        SceneManager.LoadScene(5);
    }

    void SwitchToTestScene()
    {
        // Load the game scene
        SceneManager.LoadScene(1);
    }
}
