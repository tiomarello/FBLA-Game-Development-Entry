using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIScript : MonoBehaviour
{
    public ScoreManager ScoreData;
    public Level_Controller LevelData;

    public Text LevelTimeText;
    public Text ScoreText;

    private void Start()
    {
        LevelEndPoint.OnLevelEnd += DisableUI;
        Level_Controller.OnNewLevelLoaded += EnableUI;
    }

    private void LateUpdate()
    {
        ScoreText.text = "Score:" + ScoreData.PlayerScore.ToString();
        LevelTimeText.text = Mathf.Floor(LevelData.currentLevelTime).ToString();
    }

    public void EnableUI()
    {
        LevelTimeText.enabled = true;
        ScoreText.enabled = true;
    }
    public void DisableUI()
    {
        LevelTimeText.enabled = false;
        ScoreText.enabled = false;
    }

}
