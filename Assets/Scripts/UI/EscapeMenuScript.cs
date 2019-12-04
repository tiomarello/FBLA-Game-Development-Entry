using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeMenuScript : MonoBehaviour
{
    public GameObject EscapeMenuCanvas;
    private bool MenuUp;

    private void Start()
    {
        MenuUp = false;
        EscapeMenuCanvas.SetActive(MenuUp);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuUp = !MenuUp;
            EscapeMenuCanvas.SetActive(MenuUp);
        }
    }
    public void Resume()
    {
        MenuUp = false;
        EscapeMenuCanvas.SetActive(MenuUp);
    }
    public void QuitToMainMenu()
    {
        //TODO
    }
}
