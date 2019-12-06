using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIScript : MonoBehaviour
{
    public ScoreManager SM;
    public Level_Controller LC;
    public Player_Lives PL;

    public Text ScoreText;
    public Text TimeText;
    public Text LivesText;

    private void Update()
    {
        ScoreText.text = "★:" + SM.PlayerScore.ToString();
        TimeText.text = Mathf.FloorToInt(LC.currentLevelTime).ToString();
        LivesText.text = "Lives:" + PL.CurrentLives;
    }
}
