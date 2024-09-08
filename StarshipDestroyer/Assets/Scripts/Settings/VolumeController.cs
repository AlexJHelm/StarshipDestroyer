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

    private void Start()
    {
        // Initialize the slider with the current volume for the specific sound
        float currentVolume = AudioManagerScript.instance.GetVolume(targetSoundName);
        volumeSlider.value = currentVolume;
        volumeTextUI.text = currentVolume.ToString("0.0");
        
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
    }
}