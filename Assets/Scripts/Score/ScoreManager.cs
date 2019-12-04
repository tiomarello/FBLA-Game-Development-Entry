using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Level_Controller LevelControllerData;
    public int PlayerScore;

    private void Start()
    {
        LevelEndPoint.OnLevelEnd += EndLevelScore;
        Level_Controller.OnNewLevelLoaded += ResetScore;
    }

    public void AddScore(int Score)
    {
        PlayerScore += Score;
        Debug.Log(PlayerScore);
    }

    public void EndLevelScore()
    {
        if(LevelControllerData.currentLevelTime < 50)
        {
            PlayerScore += 50;
        }
    }
    public void ResetScore()
    {
        PlayerScore = 0;
    }
}
