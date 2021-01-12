using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text pointsText;

    int gold;
    string convertedGold;

    private void Start()
    {

    }

    void Update()
    {
        gold = GameManager.instance.Gold;
        convertedGold = gold.ToString();
        pointsText.text = convertedGold;
    }
}
