using DFTGames.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesDisplay : MonoBehaviour
{

    public UpgradesScriptableObj upgrade;

    public Text level;
    public Text upgradeName;
    public Text description;
    public Text comment;
    public Text cost;
    public Image image;
    private Localize localizeName;
    private Localize localizeDescription;
    private Localize localizeComment;

    private string pickaxeUpgradeNamesString = "pickaxeUpgradeNAME";
    private string pickaxeUpgradeDescriptionString = "pickaxeUpgradeDESCRIPTION";
    private string pickaxeUpgradeCommentsString = "pickaxeUpgradeCOMMENT";

    private string dwarfsUpgradeNamesString = "dwarfsUpgradeNAME";
    private string dwarfsUpgradeDescriptionString = "dwarfsUpgradeDESCRIPTION";
    private string dwarfsUpgradeComentsString = "dwarfsUpgradeCOMMENT";

    private string minesUpgradeNamesString = "minesUpgradeNAME";
    private string minesUpgradeDescriptionString = "minesUpgradeDESCRIPTION";
    private string minesUpgradeCommentsString = "minesUpgradeCOMMENT";


    void Start()
    {
        level.text = upgrade.level.ToString();
        upgradeName.text = upgrade.names[upgrade.level - 1];
        comment.text = upgrade.comments[upgrade.level - 1];
        description.text = upgrade.description;
        cost.text = upgrade.cost.ToString();
        image.sprite = upgrade.images[upgrade.level - 1];
        localizeName = upgradeName.GetComponent<Localize>();
        localizeDescription = description.GetComponent<Localize>();
        localizeComment = comment.GetComponent<Localize>();
        UpgradeUI();
    }

    public int UpgradePickaxe()
    {
        upgrade.level++;
        upgrade.cost += 10;
        comment.text = upgrade.comments[upgrade.level - 1];
        image.sprite = upgrade.images[upgrade.level - 1];

        //every 13 lvls of pickaxe upgrade changes the description
        if (upgrade.level > 0 && upgrade.level % 13 == 0)
        {
            int i = 1;
            localizeComment.localizationKey = pickaxeUpgradeCommentsString + i.ToString();
        }

        localizeName.localizationKey = pickaxeUpgradeNamesString + (upgrade.level - 1).ToString();

        UpgradeUI();
        return upgrade.level;
    }

    public int UpgradeDwarfs(int currentMultiplier)
    {
        upgrade.level++;
        upgrade.cost += 10;

        localizeName.localizationKey = dwarfsUpgradeNamesString + (upgrade.level - 1).ToString();

        UpgradeUI();
        return currentMultiplier * 10;
    }

    public int UpgradeMines(int numberOfMines)
    {
        //localizeName.localizationKey = minesUpgradeNamesString + (upgrade.level - 1).ToString();
        upgrade.level++;
        upgrade.cost += 10;
        UpgradeUI();
        return numberOfMines += 1000;
    }

    public void UpgradePreciousStones()
    {
        upgrade.level++;
        upgrade.cost += 10;

        UpgradeUI();
    }

    void UpgradeUI()
    {
        if (localizeDescription != null)
            localizeDescription.UpdateLocale();

        if (localizeComment != null)
            localizeComment.UpdateLocale();

        if (localizeName != null)
            localizeName.UpdateLocale();

        level.text = upgrade.level.ToString();
        cost.text = upgrade.cost.ToString();
    }

}
