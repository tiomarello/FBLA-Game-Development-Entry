using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Level))]
public class LevelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Level levelScript = (Level)target;

        if(GUILayout.Button("Add Objects to List"))
        {
            levelScript.LevelEntities.AddRange(Selection.gameObjects);
        }
        if(GUILayout.Button("Make Objects Inactive"))
        {
            foreach(GameObject x in Selection.gameObjects)
            {
                x.SetActive(false);
            }
        }
    }
}
