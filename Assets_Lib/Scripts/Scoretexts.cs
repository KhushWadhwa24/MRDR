using UnityEngine;
using TMPro;

public class Scoretexts : MonoBehaviour
{
  public TextMeshProUGUI textMeshPro;
  public float floatvalue;
  
    void Update()
{
    floatvalue = Shooting.score;
    textMeshPro.text = floatvalue.ToString();
}
}