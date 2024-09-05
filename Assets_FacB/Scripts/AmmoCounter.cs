using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AmmoCounter : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public Sprite ammoIcon;
    //public TouchToShoot touchToShoot;

    void Update()
    {
        UpdateAmmoText();
    }

    void UpdateAmmoText()
    {

        // Update the ammoText with the current ammo value
        ammoText.text = Mathf.Max(TouchToShoot.currentAmmo, 0).ToString();

        //ammoIcon.enabled = true;
    }
}