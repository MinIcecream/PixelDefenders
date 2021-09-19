using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "New Level", menuName = "Level")]
public class Level : ScriptableObject
{
    [Serializable]
    public struct enemyPos
    {
        public string name;
        public Vector2 transform;

        public string GetName()
        {
            return name;
        }
        public Vector2 GetTransform()
        {
            return transform;
        }
    }
    public List<enemyPos> enemies;

    public void AddEnemy(string name, Vector2 pos)
    {
        enemyPos newEnemy;
        newEnemy.name = name;
        newEnemy.transform = pos;
        enemies.Add(newEnemy);
    }
    public List<enemyPos> ReturnEnemies()
    {
        return enemies;
    }
}
