using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///Handles Gameplay UI
///</summary>
public class GameplayUIScript : MonoBehaviour
{
    
    public ScoreManager ScoreData;
    public Level_Controller LevelData;
    public Player_Lives LivesData;

    public GameObject GameplayUICanvas;
    public Text LevelTimeText;
    public Text ScoreText;
    public Text PlayerLivesText;
    
    private void Start()
    {
        LevelEndPoint.OnLevelEnd += DisableUI;
        Level_Controller.OnNewLevelLoaded += EnableUI;
        
    }
    //Update UI elements with new data
    private void LateUpdate()
    {
        ScoreText.text = "★:" + ScoreData.PlayerScore.ToString();
        LevelTimeText.text = Mathf.Floor(LevelData.currentLevelTime).ToString();
        PlayerLivesText.text = "Lives:" + LivesData.CurrentLives;
    }
    /// <summary>
    /// Enables all Gameplay UI
    /// </summary>
    public void EnableUI()
    {
        GameplayUICanvas.SetActive(true);
    }
    /// <summary>
    /// Disables all Gameplay UI
    /// </summary>
    public void DisableUI()
    {
        GameplayUICanvas.SetActive(false);
    }

}
