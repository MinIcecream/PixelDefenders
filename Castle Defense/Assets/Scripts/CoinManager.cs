using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private int gold;

    public void AddGold(int num)
    {
        gold += num; 
    }
    public void UseGold(int num)
    {
        gold -= num;
    }
    public int CheckGold()
    {
        return gold;
    }
    public void SetGold(int num)
    {
        gold = num;
    }
}
