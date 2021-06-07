using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(Map_generator))]
public class Map_genrationeditor : Editor
{
    public override void OnInspectorGUI()
    {
        Map_generator mapGen = (Map_generator)target;


        if (DrawDefaultInspector())
        {
            if (mapGen.auto_update)
            {
                mapGen.Generate_map();
            }
        }
        if (GUILayout.Button("Generate"))
        {
            mapGen.Generate_map();
        }
    }
}
