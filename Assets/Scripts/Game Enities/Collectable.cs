using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles behaviour for objects to be collected by the player, adding score.
/// Parent gameobject must have collider, trigger enabled.
/// </summary>
public class Collectable : MonoBehaviour
{
    /// <summary>
    /// The score to be added when object is collected. Set in editor.
    /// </summary>
    public int ScoreAmount;
    public ScoreManager SC;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Collect();
        }
    }

    private void Start()
    {
        SC = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }

    //Exected when collected by player
    public void Collect()
    {
        SC.AddScore(ScoreAmount);
        Destroy(gameObject);
    }
}
