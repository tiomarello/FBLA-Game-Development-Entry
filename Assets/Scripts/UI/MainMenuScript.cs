using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject MainMenuCanvas;
    public GameObject CreditCanvas;

    private void Start()
    {
        MainMenuCanvas.SetActive(true);
        CreditCanvas.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void QuitGame()
    {
        Application.Quit();

    }
    public void OpenCredits() 
    {
        MainMenuCanvas.SetActive(false);
        CreditCanvas.SetActive(true);
    }
    public void CloseCredits()
    {
        MainMenuCanvas.SetActive(true);
        CreditCanvas.SetActive(false);
    }
}
