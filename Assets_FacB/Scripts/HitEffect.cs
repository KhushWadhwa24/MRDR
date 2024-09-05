using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class HitEffect : MonoBehaviour
{
    public TextMeshProUGUI CpiText;
    void Update()
    {

        UpdateHealthText();
        Debug.Log(PlayerHealth.currentHealth);


    }

    void UpdateHealthText()
    {
        CpiText.text = "CPI: " + PlayerHealth.currentHealth.ToString();
    }
}