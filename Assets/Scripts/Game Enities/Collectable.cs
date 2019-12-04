using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int ScoreAmount;
    public ScoreManager SC;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Collect();
        }
    }

    private void Start()
    {
        SC = GameObject.Find("GameManager").GetComponent<ScoreManager>();
    }
    public void Collect()
    {

        SC.AddScore(ScoreAmount);
        Destroy(gameObject);
    }
}
