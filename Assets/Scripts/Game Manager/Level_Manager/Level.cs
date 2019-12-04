using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform LevelEntry;
    public List<GameObject> LevelEntities = new List<GameObject>();

    private List<GameObject> EntityManuscript;

    private void Start()
    {
        EntityManuscript = new List<GameObject>(LevelEntities);
    }

    public void LoadLevel()
    {
        foreach(GameObject x in LevelEntities)
        {
            if(x != null)
                x.SetActive(true);
        }
    }
    public void UnloadLevel()
    {
        foreach(GameObject x in LevelEntities)
        {
            if(x != null)
                x.SetActive(false);
        }
    }
    public void ReloadLevel()
    {
        foreach(GameObject x in EntityManuscript)
        {
            Instantiate(x);
        }
    }
}
