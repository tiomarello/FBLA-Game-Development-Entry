using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelIntroScript : MonoBehaviour
{
    public Level_Controller LevelController;
    public Text IntroText;

    private void Update()
    {
        IntroText.text = LevelController.GetCurrentLevel().LevelIntro;
    }
}
