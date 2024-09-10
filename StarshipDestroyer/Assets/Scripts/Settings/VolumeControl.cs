using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private TMP_Text volumeTextUI = null;
    [SerializeField] private string targetSoundName = "MenuMusic"; // Specify the sound name here
    private const string volumeKeyPrefix = "Volume_";

    private void Start()
    {
        // Load the saved volume from PlayerPrefs
        float savedVolume = PlayerPrefs.GetFloat(volumeKeyPrefix + targetSoundName, 1f); // Default volume is 1
        volumeSlider.value = savedVolume;
        volumeTextUI.text = savedVolume.ToString("0.0");

        // Initialize the volume in the AudioManagerScript
        if (AudioManagerScript.instance != null)
        {
            AudioManagerScript.instance.SetVolume(targetSoundName, savedVolume);
        }

        // Add a listener to the slider to call the SetVolume method on change
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        // Update the volume text
        volumeTextUI.text = volume.ToString("0.0");

        // Update the volume in the AudioManagerScript for the specific sound
        if (AudioManagerScript.instance != null)
        {
            AudioManagerScript.instance.SetVolume(targetSoundName, volume);
        }

        // Save the volume setting to PlayerPrefs
        PlayerPrefs.SetFloat(volumeKeyPrefix + targetSoundName, volume);
        PlayerPrefs.Save(); // Make sure to save the PlayerPrefs data
    }
}
