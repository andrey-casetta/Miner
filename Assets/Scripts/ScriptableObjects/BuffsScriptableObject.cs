using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buff", menuName = "Buff")]
public class BuffsScriptableObject : ScriptableObject {

    public new string name;
    public string description;
    public string comment;
    public int cost;
    public int duration;
    public Sprite image;

    private void OnEnable()
    {
        cost = 10;
    }
}
