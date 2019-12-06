using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Handles behaviour obstacles that send the player back to the start of the level.
/// Parent gameobject must have collider, triger enabled.
/// </summary>
public class DeathZone : MonoBehaviour
{
    public delegate void DeathZoneDelegate();
    //Called when player 
    public static event DeathZoneDelegate OnFellOutOfMap;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            OnFellOutOfMap?.Invoke();
            Debug.Log("Player Fell Into Out Of Bounds Zone");
        }
    }
}
