using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntroUI : MonoBehaviour
{

    public GameObject LevelIntroCanvas;
    public Level_Controller LevelControllerData;
    public Text LevelIntroText;

    private void Start()
    {
        Level_Controller.OnNewLevelLoaded += ShowLevelIntro;
        ShowLevelIntro();
    }
    public void ShowLevelIntro()
    {
        
        LevelIntroText.text = LevelControllerData.GetCurrentLevel().LevelIntro;
        LevelIntroCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        LevelIntroCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
