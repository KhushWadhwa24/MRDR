using UnityEngine;
using TMPro;

public class Scoretext : MonoBehaviour
{
  public TextMeshProUGUI textMeshPro;
  public float floatvalue;
  void Update()
{
  floatvalue = Shooting.score;
  textMeshPro.text = "Score :" + floatvalue.ToString();
}
}