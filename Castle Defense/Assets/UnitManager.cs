using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    private static List<string> playerUnits = new List<string>() { "Calvalry", "Crossbower", "Knight", "Peasant", "Soldier" };
    private static List<string> enemyUnits = new List<string>() { "Chomper", "Orc Chieftan", "Orc Druid", "Orc Flagbearer", "Orc Giant" };
    private static List<string> allUnits = new List<string>(){ "Calvalry", "Crossbower", "Knight", "Peasant", "Soldier", "Chomper", "Orc Chieftan", "Orc Druid", "Orc Flagbearer", "Orc Giant" };

    public static List<string> PlayerUnits()
    {
        return playerUnits;
    }
    public static List<string> EnemyUnits()
    {
        return enemyUnits;
    }
    public static List<string> AllUnits()
    {
        return allUnits;
    }
}
