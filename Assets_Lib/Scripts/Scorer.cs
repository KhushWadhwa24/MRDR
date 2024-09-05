using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    void Update()
    {
        textMeshPro.text = "Fishes Caught: " + Shooting.score.ToString("F0");  // Ensure time does not go negative and format to 2 decimal places
    }
}
