using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuJ : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameScene()
    {
        SceneManager.LoadScene(2);
    }

    public void WinScene()
    {
        SceneManager.LoadScene(3);
    }

    public void Credits()
    {
        SceneManager.LoadScene(4);
    }
    public void Options()
    {
        SceneManager.LoadScene(5);
    }

    public void HandbookOBJ()
    {
        SceneManager.LoadScene(6);
    }

    public void HandbookShip()
    {
        SceneManager.LoadScene(7);
    }

    public void HandbookFighter()
    {
        SceneManager.LoadScene(8);
    }

    public void HandbookSecond()
    {
        SceneManager.LoadScene(9);
    }

    public void HandbookMission()
    {
        SceneManager.LoadScene(10);
    }

    public void News()
    {
        SceneManager.LoadScene(11);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}