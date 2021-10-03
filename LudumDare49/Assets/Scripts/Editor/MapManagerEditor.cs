using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapManager))]
public class MapManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MapManager mapManager = (MapManager)target;

        if (GUILayout.Button("Generate Map"))
        {
            mapManager.GenerateMap();
        }
        if (GUILayout.Button("Delete Map"))
        {
            mapManager.DeleteMap();
        }

    }
}