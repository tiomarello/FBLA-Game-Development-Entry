﻿using System.Collections;
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

    private void Start()
    {
        CurrentLives = StartingLives;
        Level_Controller.OnLevelRestart += SubstractLife;
    }
    private void Update()
    {
        Debug.Log(CurrentLives);
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
        Debug.Log("Took off a life");
    }
    public void SubstractLife(int i)
    {
        CurrentLives -= i;
    }

}
