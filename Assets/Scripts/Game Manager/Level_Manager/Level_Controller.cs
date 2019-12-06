using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the loading and unloading of levels, player respawning, and time elapsed since start.
/// </summary>
public class Level_Controller : MonoBehaviour
{
    /// <summary>
    /// List of entities, populated in editor.
    /// </summary>
    public List<Level> LevelEntryPoints = new List<Level>();
    public GameObject Player;

    public delegate void Level_ControllerDelegate();
    public static event Level_ControllerDelegate OnNewLevelLoaded;
    public static event Level_ControllerDelegate OnLevelRestart;


    private int currentLevel;
    private GameObject CurrentPlayerObject;

    /// <summary>
    /// Time in seconds since current level started.
    /// </summary>
    public float currentLevelTime;
    
    private void Start()
    {
        currentLevel = 0;

        
        CurrentPlayerObject = Instantiate(Player, LevelEntryPoints[0].LevelEntry.position, Quaternion.identity) as GameObject;
        
        DeathZone.OnFellOutOfMap += RestartPlayer;

        Time.timeScale = 0;
    }

    private void Update()
    {
        currentLevelTime += Time.deltaTime;
    }

    /// <summary>
    /// Sets player back to beginning of the level
    /// </summary>
    public void RestartPlayer()
    {
        Destroy(CurrentPlayerObject);
        CurrentPlayerObject = Instantiate(Player, LevelEntryPoints[currentLevel].LevelEntry.position, Quaternion.identity) as GameObject;
        OnLevelRestart?.Invoke();
    }

    /// <summary>
    /// Unloads current level and loads new level/Resets elapsed time.
    /// </summary>
    public void LoadNewLevel()
    {
        currentLevelTime = 0;

        LevelEntryPoints[currentLevel].UnloadLevel();
        currentLevel++;
        LevelEntryPoints[currentLevel].LoadLevel();

        Destroy(CurrentPlayerObject);
        CurrentPlayerObject = Instantiate(Player, LevelEntryPoints[currentLevel].LevelEntry) as GameObject;

        OnNewLevelLoaded?.Invoke();
    }
    public void LoadMainMenu()
    {
        Time.timeScale = 0;
        LevelEntryPoints[currentLevel].UnloadLevel();
        currentLevel = 0;
        Destroy(CurrentPlayerObject);
        CurrentPlayerObject = Instantiate(Player, LevelEntryPoints[currentLevel].LevelEntry) as GameObject;
    }

    /// <summary>
    /// Returns the currently loaded level.
    /// </summary>
    public Level GetCurrentLevel()
    {
        return LevelEntryPoints[currentLevel];
    }
}
