using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class LevelCreator : MonoBehaviour
{
    public Level level;

#if UNITY_EDITOR
    public void SaveLevel()
    {
    Debug.Log("DJ");
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Ogre");

        if (level != null)
        {
            EditorUtility.SetDirty(level);
            foreach (GameObject obj in objs)
            {
                level.AddEnemy(obj.GetComponent<OgreManager>().ogre.name, obj.transform.position);
            }
        }
    }
}
[CustomEditor(typeof(LevelCreator))]
public class LevelCreatorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelCreator creator = (LevelCreator)target;
        if (GUILayout.Button("Save Level"))
        {
            creator.SaveLevel();
        }
    }
#endif
}
