using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private static List<string> playerUnits = new List<string>() { };
    private static List<string> enemyUnits = new List<string>() {  };
    private static List<string> allUnits = new List<string>(){ };

    public static List<string> PlayerUnits()
    {
        UpdateDatabase();
        return playerUnits;
    }
    public static List<string> EnemyUnits()
    {
        UpdateDatabase();
        return enemyUnits;
    }
    public static List<string> AllUnits()
    {
        UpdateDatabase();
        return allUnits;
    }

    static void UpdateDatabase()
    {
        foreach (GameObject unit in Resources.LoadAll("Unit Prefabs/Player Units"))
        {
 
            if (!allUnits.Contains(unit.name))
            {
                playerUnits.Add(unit.name);
                allUnits.Add(unit.name);
            }

        }
        foreach (GameObject unit in Resources.LoadAll("Unit Prefabs/Enemy Units"))
        {
            if (!allUnits.Contains(unit.name))
            {
                enemyUnits.Add(unit.name);
                allUnits.Add(unit.name);
            }
 
        }
    }

}
