using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUIScript : MonoBehaviour
{
    public ScoreManager ScoreData;

    public Text ScoreText;

    private void LateUpdate()
    {
        ScoreText.text = "Score:" + ScoreData.PlayerScore.ToString();
    }

}
