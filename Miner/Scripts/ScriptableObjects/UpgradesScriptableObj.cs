using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "Upgrade")]
public class UpgradesScriptableObj : ScriptableObject
{
    public int level;
    public int cost;
    public string description;
    public string[] names;
    public string[] comments;
    public Sprite[] images;

    private void OnEnable()
    {
        level = 1;
        cost = 10;
    }

}
