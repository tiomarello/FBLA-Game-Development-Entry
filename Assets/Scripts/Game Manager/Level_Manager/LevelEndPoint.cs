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

    //Invokes trigger when player enters attached trigger
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something hit Level End");
        if(other.CompareTag("Player"))
        {
            Time.timeScale = 0;
            OnLevelEnd?.Invoke();
        }
    }
            
}
