using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOfGame : MonoBehaviour
{
    public delegate void EndOfGameDelegate();
    public static event EndOfGameDelegate OnEndOfGame;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")){
            OnEndOfGame?.Invoke();
        }
    }

}
