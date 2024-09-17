using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void MainMenu()
    {
        GameManager.GM.inGame = false;
        GameManager.GM.onWinScene = false;
        SceneManager.LoadScene(0);
        AudioManagerScript.instance.Stop("WinMusic");
        AudioManagerScript.instance.Stop("LoseMusic");
        AudioManagerScript.instance.Stop("GameMusic");
        AudioManagerScript.instance.Stop("Engine");
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.menuMusicPlaying == false)
        {
            AudioManagerScript.instance.Play("MenuMusic");
            GameManager.GM.menuMusicPlaying = true;
        }
    }

    public void PlayGame()
    {
        GameManager.GM.laserSystemActive = true;
        GameManager.GM.inSetup = true;
        GameManager.GM.onUpgradeScreen = true;
        GameManager.GM.onLaunchScreen = false;
        GameManager.GM.onWeaponsScreen = false;
        GameManager.GM.inGame = false;
        GameManager.GM.onWinScene = false;
        SceneManager.LoadScene(1);
        AudioManagerScript.instance.Stop("WinMusic");
        AudioManagerScript.instance.Stop("LoseMusic");
        AudioManagerScript.instance.Play("Click");
        if (GameManager.GM.menuMusicPlaying == false)
        {
            AudioManagerScript.instance.Play("MenuMusic");
            GameManager.GM.menuMusicPlaying = true;
        }
    }

    public void GameScene()
    {
        if(GameManager.GM.remainingAllocationSlots == 0)
        {
            GameManager.GM.maxFighters = GameManager.GM.fightersAllocated;
            GameManager.GM.maxBombers = GameManager.GM.bombersAllocated;
            GameManager.GM.maxDefenders = GameManager.GM.defendersAllocated;
            GameManager.GM.enemyWeakpointsDestroyed = 0;
            GameManager.GM.allyWeakpointsDestroyed = 0;
            GameManager.GM.cutscenePlaying = false;
            GameManager.GM.enemyBridgeDestroyed = false;
            GameManager.GM.enemyWeaponsDestroyed = false;
            GameManager.GM.enemyThrustersDestroyed = false;
            GameManager.GM.fightersAlive = 0;
            GameManager.GM.enemyFightersAlive = 0;
            GameManager.GM.bombersAlive = 0;
            GameManager.GM.enemyBombersAlive = 0;
            GameManager.GM.defendersAlive = 0;
            GameManager.GM.enemyDefendersAlive = 0;
            GameManager.GM.scrapGained = 0;
            GameManager.GM.fightersDestroyed = 0;
            GameManager.GM.bombersDestroyed = 0;
            GameManager.GM.defendersDestroyed = 0;
            GameManager.GM.totalDestroyed = 0;
            GameManager.GM.canSpawn = true;
            GameManager.GM.asteroidCanSpawn = true;
            GameManager.GM.inSetup = false;
            GameManager.GM.onLaunchScreen = false;
            GameManager.GM.shipSelected = false;
            GameManager.GM.inGame = true;
            SceneManager.LoadScene(2);
            AudioManagerScript.instance.Stop("MenuMusic");
            GameManager.GM.menuMusicPlaying = false;
            AudioManagerScript.instance.Play("GameMusic");
            AudioManagerScript.instance.Play("Engine");
        }     
    }

    public void WinScene()
    {
        GameManager.GM.inGame = false;
        GameManager.GM.onWinScene = true;
        SceneManager.LoadScene(3);
    }    
    public void LoseScene()
    {
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(4);
    }

    public void Credits()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(5);
    }

    public void OptionsControlMovement()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(6);
    }

    public void HandbookPlayer()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(7);
    }

    public void HandbookOBJ()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(8);
    }

    public void HandbookBoost()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(9);
    }

    public void HandbookScrap()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(10);
    }

    public void HandbookShips()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(11);
    }

    public void News()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(12);
    }

    public void Allocations()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        GameManager.GM.onUpgradeScreen = false;
        GameManager.GM.onLaunchScreen = false;
        GameManager.GM.inSetup = true;
        SceneManager.LoadScene(13);
    }

    public void Weapons()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        GameManager.GM.onUpgradeScreen = false;
        GameManager.GM.inSetup = false;
        GameManager.GM.onWeaponsScreen = true;
        GameManager.GM.onLaunchScreen = false;
        SceneManager.LoadScene(14);
    }

    public void Launch()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        GameManager.GM.onUpgradeScreen = false;
        GameManager.GM.inSetup = false;
        GameManager.GM.onWeaponsScreen = false;
        GameManager.GM.onLaunchScreen = true;
        SceneManager.LoadScene(15);
    }

    public void OptionsControlCombat()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(16);
    }

    public void OptionsVideo()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(17);
    }

    public void OptionsAudioMusic()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(18);
    }
    public void OptionsAudioSFX()
    {
        AudioManagerScript.instance.Play("Click");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(19);
    }

    public void CutsceneWin()
    {
        AudioManagerScript.instance.Stop("Engine");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(20);
    }

    public void CutsceneLose()
    {
        AudioManagerScript.instance.Stop("Engine");
        GameManager.GM.inGame = false;
        SceneManager.LoadScene(21);
    }


    public void QuitGame()
    {
        AudioManagerScript.instance.Play("Click");
        Application.Quit();
    }
}