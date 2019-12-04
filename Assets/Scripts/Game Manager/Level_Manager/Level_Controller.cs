using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Controller : MonoBehaviour
{
    public List<Level> LevelEntryPoints = new List<Level>();
    public GameObject Player;

    public delegate void Level_ControllerDelegate();
    public static event Level_ControllerDelegate OnNewLevelLoaded;

    private int currentLevel;
    private GameObject CurrentPlayerObject;

    public float currentLevelTime;
    
    private void Start()
    {
        //Component Intilization//
        CurrentPlayerObject = GameObject.FindGameObjectWithTag("Player");

        //Variable Initilization//
        currentLevel = 0;

        //Functions//
        LevelEntryPoints[0].LoadLevel();

        //Event Assignments//
        DeathZone.OnFellOutOfMap += RestartPlayer;
    }
    private void Update()
    {
        currentLevelTime += Time.deltaTime;
    }
    public void RestartPlayer()
    {
        Destroy(CurrentPlayerObject);
        CurrentPlayerObject = Instantiate(Player, LevelEntryPoints[currentLevel].LevelEntry) as GameObject;
    }

    public void LoadNewLevel()
    {
        currentLevelTime = 0;

        LevelEntryPoints[currentLevel].UnloadLevel();
        currentLevel++;
        LevelEntryPoints[currentLevel].LoadLevel();

        Destroy(CurrentPlayerObject);
        CurrentPlayerObject = Instantiate(Player, LevelEntryPoints[currentLevel].LevelEntry) as GameObject;

        OnNewLevelLoaded?.Invoke();
        Time.timeScale = 1;
    }




}
