using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;  // Import UI to access Text and Button components

public class ScreenMode : MonoBehaviour
{
    public TMP_Text buttonText;  // Reference to the button text

    // Method to toggle fullscreen and update the button text
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        UpdateButtonText(isFullscreen);
    }

    // Method to update button text based on the fullscreen mode
    private void UpdateButtonText(bool isFullscreen)
    {
        if (isFullscreen)
        {
            buttonText.text = "Full Screen";
        }
        else
        {
            buttonText.text = "Windowed";
        }
    }

    // Optional: Automatically update button text based on initial screen mode
    private void Start()
    {
        UpdateButtonText(Screen.fullScreen);
    }
}