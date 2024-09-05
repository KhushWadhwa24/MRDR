using UnityEngine;
using TMPro;

public class Time1 : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;  // Ensure this is assigned in the Inspector
    public float elapsedTime = 0f;  // Tracks the time elapsed
    public float totalTime = 30f;  // Total time for the countdown
    public static float timeLeft = 0f;

    void Update()
    {
        // Update elapsed time
        elapsedTime += Time.deltaTime;

        // Calculate time left
        timeLeft = totalTime - elapsedTime;

        // Display time left on UI
        textMeshPro.text = Mathf.Max(timeLeft, 0f).ToString("F0");  // Ensure time does not go negative and format to 2 decimal places
    }
}
