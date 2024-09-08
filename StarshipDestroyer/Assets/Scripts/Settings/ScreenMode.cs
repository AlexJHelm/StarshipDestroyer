using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScreenMode : MonoBehaviour
{
    public TMP_Text buttonText;  // Reference to the button text
    private const string FullscreenPrefKey = "FullscreenMode";  // Key for saving fullscreen state

    private static ScreenMode instance;  // Singleton instance to ensure one object

    // Method to toggle fullscreen and update the button text
    public void ToggleFullscreen()
    {
        // Toggle fullscreen state
        bool isFullscreen = !Screen.fullScreen;
        Screen.fullScreen = isFullscreen;

        // Save the fullscreen state
        PlayerPrefs.SetInt(FullscreenPrefKey, isFullscreen ? 1 : 0);
        PlayerPrefs.Save();  // Ensure the state is saved immediately

        // Update the button text
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

    // Automatically update button text and screen mode based on saved preference
    private void Start()
    {
        // Prevent duplication of the object when reloading scenes
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Make this object persistent
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate instances
            return;  // Prevent further execution for duplicates
        }

        // Check if fullscreen preference exists, otherwise use the current screen mode
        bool isFullscreen = PlayerPrefs.GetInt(FullscreenPrefKey, Screen.fullScreen ? 1 : 0) == 1;

        // Apply the saved fullscreen mode
        Screen.fullScreen = isFullscreen;

        // Update the button text to match the saved state
        UpdateButtonText(isFullscreen);
    }
}