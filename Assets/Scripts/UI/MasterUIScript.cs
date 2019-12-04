using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterUIScript : MonoBehaviour
{
    public GameObject NextLevelMenuCanvas;

    private void Awake()
    {
        LevelEndPoint.OnLevelEnd += EnableNextLevelMenu;
        Level_Controller.OnNewLevelLoaded += DisableNextLevelMenu;
    }

    public void EnableNextLevelMenu()
    {
        NextLevelMenuCanvas.SetActive(true);
    }
    public void DisableNextLevelMenu()
    {
        NextLevelMenuCanvas.SetActive(false);

    }
}
