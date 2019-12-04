using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    
    public int PlayerScore;

    public void AddScore(int Score)
    {
        PlayerScore += Score;
        Debug.Log(PlayerScore);
    }
}
