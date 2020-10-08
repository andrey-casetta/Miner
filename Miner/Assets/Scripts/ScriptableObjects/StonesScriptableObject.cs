using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stone", menuName = "Stone")]
public class StonesScriptableObject : ScriptableObject {
    public int level;
    public int maxHealth;
    public int phase1Health;
    public int phase2Health;
    public int phase3Health;
    public Sprite[] stoneImages;
}
