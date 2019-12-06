using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lives : MonoBehaviour
{
    /// <summary>
    /// Amount of lives player starts with.
    /// Set in editor.
    /// </summary>
    public int StartingLives;
    [HideInInspector]
    public int CurrentLives;

    public delegate void Player_LivesDelegate();
    public static event Player_LivesDelegate OnGameOver;

    private void Start()
    {
        CurrentLives = StartingLives;
        Level_Controller.OnLevelRestart += SubstractLife;
    }
    
    public void CheckGameOver()
    {
        if(CurrentLives <= 0)
        {
            OnGameOver?.Invoke();
            Time.timeScale = 0;
        }
    }

    //Different Operators on the current amount of lives //
    //For other classes to call //
     
    public void AddLife()
    {
        CurrentLives += 1;
    }
    public void AddLife(int i)
    {
        CurrentLives += i;
    }
    public void SubstractLife()
    {
        CurrentLives -= 1;
        CheckGameOver();
        Debug.Log("Took off a life");
    }
    public void SubstractLife(int i)
    {
        CurrentLives -= i;
        CheckGameOver();
    }

}
