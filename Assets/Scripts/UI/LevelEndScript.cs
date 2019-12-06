using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelEndScript : MonoBehaviour
{
    public Text EndOflevelText;
    public Text FinalScore;
    public Level_Controller LC;
    public ScoreManager SC;

    private void LateUpdate()
    {
        EndOflevelText.text = LC.GetCurrentLevel().LevelEnding;
        FinalScore.text = "Final Score:" + SC.PlayerScore;
    }
}
