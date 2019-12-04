using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndPoint : MonoBehaviour
{
    public delegate void levelendDelegate();
    public static event levelendDelegate OnLevelEnd;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Something hit Level End");
        if(other.tag == "Player")
        {
            Time.timeScale = 0;
            OnLevelEnd?.Invoke();
        }
    }
            
}
