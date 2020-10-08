using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ActiveUpgradesAndBuffs : MonoBehaviour
{
    public static ActiveUpgradesAndBuffs instance;
    GameManager gameManagerInstance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        gameManagerInstance = GameManager.instance;
    }

    private bool dwarfsIsActive = false;
    private bool minesIsActive = false;
    private bool strengthBuffActive = false;
    private bool twoHandedBuffActive = false;
    private bool fourLeafCloverBuffActive = false;
    private bool preciousStonesActive = false;

    private int dwarfsMultiplier = 1;
    private int numberOfMines = 0;

    //all buff durations are defined in the scriptable objects of the buffs
    private int strengthBuffDuration;
    private int twoHandedBuffDuration;
    private int fourLeafCloveBuffDuration;
    private int preciousStonesBuffDuration;

    public bool DwarfsIsActive
    {
        get
        {
            return dwarfsIsActive;
        }

        set
        {
            dwarfsIsActive = value;
        }
    }

    public bool MinesIsActive
    {
        get
        {
            return minesIsActive;
        }

        set
        {
            minesIsActive = value;
        }
    }

    public bool PreciousStonesActive
    {
        get
        {
            return preciousStonesActive;
        }

        set
        {
            preciousStonesActive = value;
        }
    }

    public bool StrengthBuffActive
    {
        get
        {
            return strengthBuffActive;
        }

        set
        {
            strengthBuffActive = value;
        }
    }

    public int DwarfsMultiplier
    {
        get
        {
            return dwarfsMultiplier;
        }

        set
        {
            dwarfsMultiplier = value;
        }
    }

    public int NumberOfMines
    {
        get
        {
            return numberOfMines;
        }

        set
        {
            numberOfMines = value;
        }
    }

    public bool TwoHandedBuffActive
    {
        get
        {
            return twoHandedBuffActive;
        }

        set
        {
            twoHandedBuffActive = value;
        }
    }

    public bool FourLeafCloverBuffActive
    {
        get
        {
            return fourLeafCloverBuffActive;
        }

        set
        {
            fourLeafCloverBuffActive = value;
        }
    }

    public void UpgradePickAxe(ref int currentToolLevel)
    {
        int upgradeCost;
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out upgradeCost))
        {
            if (gameManagerInstance.Gold >= upgradeCost)
            {
                gameManagerInstance.Gold -= upgradeCost;
                currentToolLevel = buttonClicked.transform.parent.GetComponent<UpgradesDisplay>().UpgradePickaxe();
            }
            else
            {
                Debug.Log("dinheiro insuficiente");
            }
        }
    }

    public void UpgradeDwarfs()
    {
        int upgradeCost;
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out upgradeCost))
        {
            if (gameManagerInstance.Gold >= upgradeCost)
            {
                gameManagerInstance.Gold -= upgradeCost;
                DwarfsMultiplier = buttonClicked.transform.parent.GetComponent<UpgradesDisplay>().UpgradeDwarfs(DwarfsMultiplier);

                if (!DwarfsIsActive)
                {
                    InvokeRepeating("ActivateDwarfs", 1, 1);
                    DwarfsIsActive = true;
                }
            }
            else
            {
                Debug.Log("dinheiro insuficiente");
            }
        }
    }

    public void UpgradeMines()
    {
        int upgradeCost;
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out upgradeCost))
        {
            if (gameManagerInstance.Gold >= upgradeCost)
            {
                gameManagerInstance.Gold -= upgradeCost;
                NumberOfMines = buttonClicked.transform.parent.GetComponent<UpgradesDisplay>().UpgradeMines(NumberOfMines);

                if (!MinesIsActive)
                {
                    InvokeRepeating("ActivateMines", 1, 1);
                    MinesIsActive = true;
                }
            }
            else
            {
                Debug.Log("dinheiro insuficiente");
            }
        }
    }

    //public void UpgradepreciousStones()
    //{
    //    int upgradeCost;
    //    GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

    //    if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out upgradeCost))
    //    {
    //        if (gameManagerInstance.Gold >= upgradeCost)
    //        {
    //            gameManagerInstance.Gold -= upgradeCost;
    //            buttonClicked.transform.parent.GetComponent<UpgradesDisplay>().UpgradePreciousStones();
    //            preciousStonesActive = true;
    //        }
    //        else
    //        {
    //            Debug.Log("dinheiro insuficiente");
    //        }
    //    }
    //}

    private void ActivateDwarfs()
    {
        gameManagerInstance.Gold += DwarfsMultiplier;
    }

    private void ActivateMines()
    {
        gameManagerInstance.Gold += NumberOfMines;
    }

    public void ActiveStrengthBuff()
    {
        int buffCost;
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out buffCost))
        {
            if (gameManagerInstance.Gold >= buffCost)
            {
                gameManagerInstance.Gold -= buffCost;
                strengthBuffDuration = buttonClicked.transform.parent.GetComponent<BuffDisplay>().StrengthBuff();
                StrengthBuffActive = true;
                StartCoroutine(StrengthBuffCountDown());
            }
            else
            {
                Debug.Log("dinheiro insuficiente");
            }
        }
    }

    public void ActiveTwoHandedBuff()
    {
        int buffCost;
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out buffCost))
        {
            if (gameManagerInstance.Gold >= buffCost)
            {
                gameManagerInstance.Gold -= buffCost;
                twoHandedBuffDuration = buttonClicked.transform.parent.GetComponent<BuffDisplay>().TwoHandedBuff();
                TwoHandedBuffActive = true;
                StartCoroutine(TwoHandedhBuffCountDown());
            }
            else
            {
                Debug.Log("dinheiro insuficiente");
            }
        }
    }

    public void ActiveFourLeafCloverBuff()
    {
        int buffCost;
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out buffCost))
        {
            if (gameManagerInstance.Gold >= buffCost)
            {
                gameManagerInstance.Gold -= buffCost;
                fourLeafCloveBuffDuration = buttonClicked.transform.parent.GetComponent<BuffDisplay>().FourLeafCloverBuff();
                FourLeafCloverBuffActive = true;
                StartCoroutine(FourLeafCloverBuffCountDown());
            }
            else
            {
                Debug.Log("dinheiro insuficiente");
            }
        }
    }

    public void ActivePreciousStonesBuff()
    {
        int buffCost;
        GameObject buttonClicked = EventSystem.current.currentSelectedGameObject;

        if (int.TryParse(buttonClicked.transform.GetChild(0).GetComponent<Text>().text, out buffCost))
        {
            if (gameManagerInstance.Gold >= buffCost)
            {
                gameManagerInstance.Gold -= buffCost;
                preciousStonesBuffDuration = buttonClicked.transform.parent.GetComponent<BuffDisplay>().PrecicousStonesBuff();
                preciousStonesActive = true;
                StartCoroutine(PreciousStonesrBuffCountDown());
            }
            else
            {
                Debug.Log("dinheiro insuficiente");
            }
        }
    }

    private IEnumerator StrengthBuffCountDown()
    {
        yield return new WaitForSeconds(strengthBuffDuration);
        strengthBuffActive = false;
    }

    private IEnumerator TwoHandedhBuffCountDown()
    {

        yield return new WaitForSeconds(twoHandedBuffDuration);
        TwoHandedBuffActive = false;
    }

    private IEnumerator FourLeafCloverBuffCountDown()
    {
        yield return new WaitForSeconds(fourLeafCloveBuffDuration);
        FourLeafCloverBuffActive = false;
    }

    private IEnumerator PreciousStonesrBuffCountDown()
    {
        yield return new WaitForSeconds(preciousStonesBuffDuration);
        preciousStonesActive = false;
    }
}
