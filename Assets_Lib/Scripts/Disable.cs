using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Disable : MonoBehaviour
{
    public Button button;
    public static bool isshooting;

    public void Start()
    {
        isshooting = false;
    }

    public void Update()
    {
        button.interactable = !isshooting;
        if (isshooting)
        {
            StartCoroutine(Delay());
        }
    }

   
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        isshooting = false;
    }

    public void SetShootingTrue()
    {
        isshooting = true;
    }

}
