using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles object which ends the level when touched.
/// Parent Gameobject must have a collider, trigger-enabled.
/// </summary>
public class LevelEndPoint : MonoBehaviour
{
    public delegate void levelendDelegate();
    public static event levelendDelegate OnLevelEnd;

    private bool EndEnabled;

    private void Start()
    {
        //Variable Initilization//
        EndEnabled = false;
    }
    //Invokes trigger when player enters attached trigger
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Something hit Level End");
        if(other.CompareTag("Player") && EndEnabled)
        {
            Time.timeScale = 0;
            OnLevelEnd?.Invoke();
        }
    }

    public void EnableEnd()
    {
        EndEnabled = true;
    }
}
