using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    [SerializeField]
    private GameObject upgradePanel;

    [SerializeField]
    private GameObject upgradesMenu;

    [SerializeField]
    private GameObject buffsMenu;

    public delegate void upgradePanelCallback(bool active);
    public upgradePanelCallback onToggleMenuUpgrade;

    private int _gold;

    public int Gold
    {
        get
        {
            return _gold;
        }

        set
        {
            _gold = value;
        }
    }

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }


    private void Update()
    {
        //Debug.Log(Gold);
    }
    private void ToggleupgradePanel()
    {
        upgradePanel.SetActive(upgradePanel.activeSelf);
        onToggleMenuUpgrade.Invoke(upgradePanel.activeSelf);
    }

    public void EnableUpgrades()
    {
        upgradesMenu.SetActive(true);
        buffsMenu.SetActive(false);
    }

    public void EnableBuffs()
    {
        upgradesMenu.SetActive(false);
        buffsMenu.SetActive(true);
    }

}
