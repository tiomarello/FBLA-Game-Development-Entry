using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelMenuScript : MonoBehaviour
{
    public Text EndLevelScoreText;
    public ScoreManager ScoreManagerData;

    private void Update()
    {
        EndLevelScoreText.text = ScoreManagerData.PlayerScore.ToString();
    }
}
