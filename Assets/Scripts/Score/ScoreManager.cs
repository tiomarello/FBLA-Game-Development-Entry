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
        Level_Controller.OnNewLevelLoaded += ResetScore;
    }

    private void Update()
    {
        CheckForLevelScoreThreshold();
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
    public int EndLevelScore()
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
        return (PlayerScore);
    }
    /// <summary>
    /// Reset player score to 0.
    /// </summary>
    public void ResetScore()
    {
        PlayerScore = 0;
    }

    public void CheckForLevelScoreThreshold()
    {
        if (PlayerScore > LevelControllerData.GetCurrentLevel().LevelScoreTreshold)
        {
            LevelControllerData.GetCurrentLevel().LevelEnd.EnableEnd();
        }
    }
}
