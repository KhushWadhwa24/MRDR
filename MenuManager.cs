using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    void Start() {
        if (volumeSlider != null) {
			volumeSlider.onValueChanged.AddListener(delegate { SnapSliderValue(); });
			volumeSlider.value = PlayerPrefs.GetFloat("Volume", 100f); // Initialize the value from PlayerPrefs
            SnapSliderValue(); // Initialize the value to the nearest multiple of 10
		}
    }

    void SnapSliderValue() {
		// Update the audio source volume
		if (AudioManager.Instance != null) {
			AudioManager.Instance.SetVolume(volumeSlider.value / 100f); // Assuming the slider range is from 0 to 100
		}

		// Save the volume setting
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
	}

    public void OnStartButtonClick() {
		Debug.Log("Start Game button clicked");
		SceneManager.LoadScene(2);
	}

	public void OnExitButtonClick() {
		Debug.Log("Exit button clicked");
		Application.Quit();
	}
}
