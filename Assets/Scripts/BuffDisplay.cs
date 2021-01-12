using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffDisplay : MonoBehaviour {

    public BuffsScriptableObject buff;

    public Text buffName;
    public Text description;
    public Text comment;
    public Text cost;
    public Text duration;
    public Image image;

    void Start()
    {
        buffName.text = buff.name;
        description.text = buff.description;
        comment.text = buff.comment;
        cost.text = buff.cost.ToString();
        duration.text = buff.duration.ToString();
        image.sprite = buff.image;
    }

    public int StrengthBuff()
    {
        buff.cost += 10;
        UpgradeUI();
        return buff.duration;
    }

    public int TwoHandedBuff()
    {
        buff.cost += 10;
        UpgradeUI();
        return buff.duration;
    }

    public int FourLeafCloverBuff()
    {
        buff.cost += 10;
        UpgradeUI();
        return buff.duration;
    }

    public int PrecicousStonesBuff()
    {
        buff.cost += 10;
        UpgradeUI();
        return buff.duration;
    }

    void UpgradeUI()
    {
        cost.text = buff.cost.ToString();
    }
}
