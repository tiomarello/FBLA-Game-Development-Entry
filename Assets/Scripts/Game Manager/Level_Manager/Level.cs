using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains the data for a level, including level entities and spawn position
/// </summary>
public class Level : MonoBehaviour
{
    /// <summary>
    /// Beginning of the level, where player is spawned
    /// </summary>
    public Transform LevelEntry;
    /// <summary>
    /// List of gameobjects not a part of the level structure.
    /// Populated in editor.
    /// </summary>
    public List<GameObject> LevelEntities = new List<GameObject>();
    /// <summary>
    /// Text shown at load level
    /// </summary>
    [TextArea]
    public string LevelIntro;

    /// <summary>
    /// Iterates through level object's entities and marks them Active
    /// </summary>
    public void LoadLevel()
    {
        foreach(GameObject x in LevelEntities)
        {
            if(x != null)
                x.SetActive(true);
        }
    }

    /// <summary>
    /// Iterates thorugh lebel object's entities and marks them Unactive for performance
    /// </summary>
    public void UnloadLevel()
    {
        foreach(GameObject x in LevelEntities)
        {
            if(x != null)
                x.SetActive(false);
        }
    }
}
