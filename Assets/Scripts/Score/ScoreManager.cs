using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Level_Controller LevelControllerData;

    /// <summary>
    /// Current player score.
    /// </summary>
    [HideInInspector]
    public int PlayerScore;

    
    private void Start()
    {
        LevelEndPoint.OnLevelEnd += EndLevelScore;
        Level_Controller.OnNewLevelLoaded += ResetScore;
    }
    /// <summary>
    /// Add an integer to current player score.
    /// </summary>
    /// <param name="Score"></param>
    public void AddScore(int Score)
    {
        PlayerScore += Score;
    }

    /// <summary>
    /// Sum up player score at end of level, including bonuses, penalities, etc.
    /// </summary>
    public void EndLevelScore()
    {
        //Score bonuses/penalities are added onto end of level score//

        //If player finishes within 30 seconds, add 50
        if(LevelControllerData.currentLevelTime < 30)
        {
            AddScore(50);
        }
        else if(LevelControllerData.currentLevelTime < 60)
        {
            AddScore(25);
        }
        else if(LevelControllerData.currentLevelTime > 120)
        {
            AddScore(-60);
        }
    }
    /// <summary>
    /// Reset player score to 0.
    /// </summary>
    public void ResetScore()
    {
        PlayerScore = 0;
    }
}
