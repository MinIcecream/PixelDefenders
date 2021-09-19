using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinUI : MonoBehaviour
{
    public CoinManager coin;
    public TextMeshProUGUI tmp;

    public void Update()
    {
        tmp.text = coin.CheckGold().ToString();
    }

}
