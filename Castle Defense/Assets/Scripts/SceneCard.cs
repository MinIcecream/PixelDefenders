using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SceneCard", menuName = "SceneCard")]
public class SceneCard : ScriptableObject
{
    public Color mainColor;
    public Color buttonColor;
    public int totalLevels;
    public int completedLevel;
    public int sceneNumber;
}
