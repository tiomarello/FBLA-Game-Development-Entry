using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterUIScript : MonoBehaviour
{
    public GameObject EscapeMenu;
    public GameObject LevelIntro;
    public GameObject GameplayUI;
    public GameObject GameOverScreen;
    public GameObject NextLevelMenu;
    public GameObject MainMenuCanvas;
    public GameObject MainMenuAcknowledgementsCanvas;
    public Level_Controller LevelController;
    public Player_Lives PlayerLives;
    public GameObject EndOfGameMenu;
    public bool EscapeMenuEnabled;
    public bool CheckForEscapeInput;

    private void Start()
    {
        EscapeMenuEnabled = false;
        //Event Assignment
        Level_Controller.OnNewLevelLoaded += OpenLevelIntro;
        Player_Lives.OnGameOver += GameoverUIEnabled;
        LevelEndPoint.OnLevelEnd += NextlevelmenuEnabled;
        EndOfGame.OnEndOfGame += EndOFGame;
        OpenMainMenu();
    }
    private void Update()
    {
        if (CheckForEscapeInput)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                EscapeMenuEnabled = !EscapeMenuEnabled;

            }
        }
        EscapeMenu.SetActive(EscapeMenuEnabled);
    }
    //Main Menu Fuctionality

    public void OpenMainMenu()
    {
        GameplayMenuDisabled();
        MainMenuCanvas.SetActive(true);
        CheckForEscapeInput = false;
    }
    public void MainMenuPlayButton()
    {
        
        MainMenuCanvas.SetActive(false);
        CheckForEscapeInput = true;
        LevelController.LoadNewLevel();
    }
    public void MainmenuQuitGameButton()
    {
        Application.Quit();
    }
    public void MainMenuOpenCredits()
    {
        MainMenuCanvas.SetActive(false);
        MainMenuAcknowledgementsCanvas.SetActive(true);
    }
    public void MainMenuCreditsClose()
    {
        MainMenuCanvas.SetActive(true);
        MainMenuAcknowledgementsCanvas.SetActive(false);
    }

    //Level Intro Functionality
    public void OpenLevelIntro()
    {
        Time.timeScale = 0;
        GameplayMenuDisabled();
        LevelIntro.SetActive(true);
        
    }
    public void LevelIntroButtonClose()
    {
        GameplayMenuEnabled();
        LevelIntro.SetActive(false);
        Time.timeScale = 1;
    }
    //Escape Menu
    public void EscapeMenuResume()
    {
        EscapeMenuEnabled = false;
    }
    public void EscapeMenuQuit()
    {
        LevelController.LoadMainMenu();
        EscapeMenuEnabled = false;
        OpenMainMenu();
    }
    //Gameplay UI
    public void GameplayMenuEnabled()
    {
        GameplayUI.SetActive(true);
    }
    public void GameplayMenuDisabled()
    {
        GameplayUI.SetActive(false);
    }
    //Gameover UI
    public void GameoverUIEnabled()
    {
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
    }
    public void GameoverUIButton()
    {
        GameOverScreen.SetActive(false);
        LevelController.LoadMainMenu();
        OpenMainMenu();
    }
    //Level End UI
    public void NextlevelmenuEnabled()
    {
        NextLevelMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void NextLevelmenubutton()
    {
        LevelController.LoadNewLevel();
        NextLevelMenu.SetActive(false);
    }
    public void EndOFGame()
    {
        EndOfGameMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void EndOfGameButton()
    {
        LevelController.LoadMainMenu();
        OpenMainMenu();
        EndOfGameMenu.SetActive(false);

    }
}
