using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(ScreenShakeManager))]
public class ScreenShakeCustomEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ScreenShakeManager screenShakeManager = (ScreenShakeManager)target;
        if(GUILayout.Button("Start shake"))
        {
            screenShakeManager.StartShake();
        }
    }
}
