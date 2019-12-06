using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollectable : MonoBehaviour
{

    public LevelEndPoint EndOfLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EndOfLevel.EnableEnd();
            this.gameObject.SetActive(false);
        }
    }

}
