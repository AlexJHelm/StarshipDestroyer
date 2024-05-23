using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MainMenu()
    {
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(0);
    }

    public void PlayGame()
    {
        GameManager.GM.inSetup = true;
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(1);
    }

    public void GameScene()
    {
        GameManager.GM.maxFighters = GameManager.GM.fightersAllocated;
        GameManager.GM.maxBombers = GameManager.GM.bombersAllocated;
        GameManager.GM.maxDefenders = GameManager.GM.defendersAllocated;
        GameManager.GM.enemyWeakpointsDestroyed = 0;
        GameManager.GM.allyWeakpointsDestroyed = 0;
        GameManager.GM.enemyBridgeDestroyed = false;
        GameManager.GM.enemyWeaponsDestroyed = false;
        GameManager.GM.enemyThrustersDestroyed = false;
        GameManager.GM.fightersAlive = 0;
        GameManager.GM.enemyFightersAlive = 0;
        GameManager.GM.bombersAlive = 0;
        GameManager.GM.enemyBombersAlive = 0;
        GameManager.GM.defendersAlive = 0;
        GameManager.GM.enemyDefendersAlive = 0;
        GameManager.GM.canSpawn = true;
        GameManager.GM.asteroidCanSpawn = true;
        GameManager.GM.inSetup = false;
        GameManager.GM.inGame = true;
        SceneManager.LoadScene(2);
    }

    public void WinScene()
    {
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(3);
    }    
    public void LoseScene()
    {
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(4);
    }

    public void Instructions()
    {
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(5);
    }

    public void Credits()
    {
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(6);
    }

    public void Options()
    {
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(7);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}