using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class Mining : MonoBehaviour
{
    public int currentToolLevel = 1;

    public ParticleSystem particles;
    string JewelTag = "Jewel";
    string PointOnScreenTag = "PointOnScreen";
    bool mining = false;
    private int preciousStonesEffect = 1;

    //counting variables
    #region

    private int blueTriangles = 0;
    private int redTriangles = 0;
    private int greenTriangles = 0;
    private int purpleTriangles = 0;
    private int blackTriangles = 0;
    private int whiteTriangles = 0;

    private int blueSquares = 0;
    private int redSquares = 0;
    private int greenSquares = 0;
    private int purpleSquares = 0;
    private int blackSquares = 0;
    private int whiteSquares = 0;

    private int blueOctagons = 0;
    private int redOctagons = 0;
    private int greenOctagons = 0;
    private int purpleOctagons = 0;
    private int blackOctagons = 0;
    private int whiteOctagons = 0;

    private int blueLozanges = 0;
    private int redLozanges = 0;
    private int greenLozanges = 0;
    private int purpleLozanges = 0;
    private int blackLozanges = 0;
    private int whiteLozanges = 0;

    private int blueHexadecagons = 0;
    private int redHexadecagons = 0;
    private int greenHexadecagons = 0;
    private int purpleHexadecagons = 0;
    private int blackHexadecagons = 0;
    private int whiteHexadecagons = 0;

    private int blueDiamonds = 0;
    private int redDiamonds = 0;
    private int greenDiamonds = 0;
    private int purpleDiamonds = 0;
    private int blackDiamonds = 0;
    private int whiteDiamonds = 0;

    #endregion

    GameManager gameManagerInstance;
    ConstantValues constantIntance;
    ActiveUpgradesAndBuffs upgradesAndBuffsInstace;
    ObjPoolerScript objectPoolerInstance;

    private void Start()
    {
        gameManagerInstance = GameManager.instance;
        upgradesAndBuffsInstace = ActiveUpgradesAndBuffs.instance;
        objectPoolerInstance = ObjPoolerScript.instance;

        gameManagerInstance.onToggleMenuUpgrade += OnUpgradeMenuToggle;
    }

    void Update()
    {
        Vector3 mouseClickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseClickPosition.z = 0;
        transform.position = mouseClickPosition;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100f))
        {
            if (hit.transform.gameObject.layer == 8)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    particles.transform.position = mouseClickPosition;
                    hit.transform.gameObject.GetComponent<Stones>().LosesHp(upgradesAndBuffsInstace.StrengthBuffActive, upgradesAndBuffsInstace.PreciousStonesActive);
                    particles.Play();
                    Mine(mouseClickPosition);
                }
            }
        }
    }

    private void Mine(Vector3 pos)
    {
        string jewelType = string.Empty;
        string jewelColor = string.Empty;
        int jewelValue = 0;

        float randomFloat = 0f;
        if (upgradesAndBuffsInstace.FourLeafCloverBuffActive)
        {
            randomFloat = Random.Range(51, 101);
        }
        else
        {
            randomFloat = Random.Range(1, 101);
        }

        switch (currentToolLevel)
        {
            //////////////////////////////// JEWEL VALUES /////////////////////////////////
            /*TRIANGLES
             green = 1 
             blue = 5
             red = 20
             purple = 50
             black = 100
             white = 300


            JEWEL     | JEWEL LEVEL

            triangle       1
            square         2
            octahedron     3
            octagon        4
            star           5
            diamond        6


            /*
            Pickaxe LVL 1 and 2 - spawns only triangles 

            spawn chance:

            lvl 1

            - green nv 1 - 70%
            - blue nv 1 -  25%
            - red nv 1 - 5%
            */

            //cases lvl pickaxe

            #region
            case 1:
                if (randomFloat <= 70)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenTriangleValue;
                    greenTriangles++;
                }
                else if (randomFloat <= 95)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueTriangleValue;
                    blueTriangles++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedTriangleValue;
                    redTriangles++;
                }

                jewelType = ConstantValues.TrianglesType;
                break;
            /*
            lvl 2
            - green nv 1 - 50%
            - blue nv 1 -  35%
            - red nv 1 - 10%
            - purple nv 1 - 5%
            */

            case 2:
                if (randomFloat <= 50)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenTriangleValue;
                    greenTriangles++;
                }
                else if (randomFloat <= 85)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueTriangleValue;
                    blueTriangles++;
                }
                else if (randomFloat <= 95)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedTriangleValue;
                    redTriangles++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    purpleTriangles++;
                }
                jewelType = ConstantValues.TrianglesType;
                break;

            /*
             lvl 3
            - green nv 1 - 30%
            - blue nv 1 -  45%
            - red nv 1 - 15%
            - purple nv 1 - 10%
             */

            case 3:
                if (randomFloat <= 30)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenTriangleValue;
                    greenTriangles++;
                }
                else if (randomFloat <= 75)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueTriangleValue;
                    blueTriangles++;
                }
                else if (randomFloat <= 90)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedTriangleValue;
                    redTriangles++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    purpleTriangles++;
                }
                jewelType = ConstantValues.TrianglesType;
                break;

            /*
           lvl 4
          -green nv 1 - 10 %
          -blue nv 1 - 50 %
          -red nv 1 - 15 %
          -purple nv 1 - 15 %
          -green nv 2 - 10 %
          */

            case 4:
                if (randomFloat <= 10)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    greenTriangles++;
                }
                else if (randomFloat <= 60)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blueTriangles++;
                }
                else if (randomFloat <= 75)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    redTriangles++;
                }
                else if (randomFloat <= 90)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    purpleTriangles++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    greenSquares++;
                }
                break;

            /*
            lvl 5

         -green nv 1 - 1 %
         -blue nv 1 - 30 %
         -red nv 1 - 20 %
         -purple nv 1 - 15 %
         -black nv 1 - 4 %
         -green nv 2 - 30 %
                */

            case 5:
                if (randomFloat == 1)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    greenTriangles++;
                }
                else if (randomFloat <= 30)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blueTriangles++;
                }
                else if (randomFloat <= 50)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    redTriangles++;
                }
                else if (randomFloat <= 65)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    purpleTriangles++;
                }
                else if (randomFloat <= 70)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    greenSquares++;
                }
                break;

            /*
            lvl 6

        - blue nv 1 - 5 %
        -red nv 1 - 25 %
        -purple nv 1 - 20 %
        -black nv 1 - 9 %
        -white nv 1 - 1 %
        -green nv 2 - 40 %
        */

            case 6:
                if (randomFloat == 1)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 26)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blueTriangles++;
                }
                else if (randomFloat <= 46)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 55)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    purpleTriangles++;
                }
                else if (randomFloat == 56)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    redTriangles++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    greenSquares++;
                }
                break;

            /*
             lvl 7
            - red nv 1 - 10%
            - purple nv 1 - 30%
            - green nv 2 - 20%
            - black nv 1 - 10%
            - white nv 1 - 1%
            - blue nv 2 - 20%
            - red nv2 - 9%
             */
            case 7:
                if (randomFloat <= 10)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    redTriangles++;
                }
                else if (randomFloat <= 40)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    purpleTriangles++;
                }
                else if (randomFloat <= 60)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    greenSquares++;
                }
                else if (randomFloat <= 70)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat == 71)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 91)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    blueSquares++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                break;

            /*
            lvl 8
            - purple nv 1 - 35%
            - green nv 2 - 10%
            - black nv 1 - 10%	
            - white nv 1 - 5%	
            - blue nv 2 - 30%	
            - red nv2 - 10%  
            */
            case 8:
                if (randomFloat <= 35)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    purpleTriangles++;
                }
                else if (randomFloat <= 45)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    greenSquares++;
                }
                else if (randomFloat <= 55)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 60)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat == 90)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    blueSquares++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                break;

            /*
            lvl 9

           - purple nv 1 - 30%
           - black nv 1 - 15%	
           - white nv 1 - 5%	
           - blue nv 2 - 35%	
           - red nv2 - 15%

            */
            case 9:
                if (randomFloat <= 30)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    purpleTriangles++;
                }
                else if (randomFloat <= 45)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 50)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 85)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    blueSquares++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                break;
            /*
            lvl 10

           - purple nv 1 - 10%
           - black nv 1 - 20%	
           - white nv 1 - 10%	
           - blue nv 2 - 40%	
           - red nv2 - 10%  
           _ green nv 3 - 10%
              */
            case 10:
                if (randomFloat <= 10)
                {
                    jewelColor = ConstantValues.PurpleColor;
                    jewelValue = ConstantValues.PurpleTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    purpleTriangles++;
                }
                else if (randomFloat <= 30)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 40)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 80)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    blueSquares++;
                }
                else if (randomFloat <= 90)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    greenOctagons++;
                }
                break;
            /*

       lvl 11

           - black nv 1 - 25%	
           - white nv 1 - 15%	
           - blue nv 2 - 30%	
           - red nv2 - 15%  
           _ green nv 3 - 15% 

             */
            case 11:
                if (randomFloat <= 25)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 40)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 70)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    blueSquares++;
                }
                else if (randomFloat <= 85)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    greenOctagons++;
                }
                break;
            /*

       lvl 12

           - black nv 1 - 30%	
           - white nv 1 - 20%	
           - blue nv 2 - 10%	
           - red nv2 - 25%  
           _ green nv 3 - 15%
     
         */
            case 12:
                if (randomFloat <= 30)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 50)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 60)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    blueSquares++;
                }
                else if (randomFloat <= 85)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    greenOctagons++;
                }
                break;
            /*
            lvl 13

           - black nv 1 - 5%	
           - white nv 1 - 25%		
           - red nv2 - 35%  
           _ green nv 3 - 30% 
           - blue nv 3 - 5%           
             */
            case 13:
                if (randomFloat <= 5)
                {
                    jewelColor = ConstantValues.BlackColor;
                    jewelValue = ConstantValues.BlackTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    blackTriangles++;
                }
                else if (randomFloat <= 30)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 65)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                else if (randomFloat <= 95)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    greenOctagons++;
                }
                else if (randomFloat <= 100)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    blueOctagons++;
                }
                break;
            /*
            lvl 14
           - white nv 1 - 30%		
           - red nv2 - 10%  
           - green nv 3 - 50% 
           - blue nv 3 - 10%
             */
            case 14:
                if (randomFloat <= 30)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 40)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                else if (randomFloat <= 90)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    greenOctagons++;
                }
                else if (randomFloat <= 10)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    blueOctagons++;
                }
                break;
            /*
             lvl 15
           - white nv 1 - 35%		
           - red nv2 - 9%  
           _ green nv 3 - 40% 
           - blue nv 3 - 15% 
           - red nv 3 - 1%     
            */
            case 15:
                if (randomFloat <= 35)
                {
                    jewelColor = ConstantValues.WhiteColor;
                    jewelValue = ConstantValues.WhiteTriangleValue;
                    jewelType = ConstantValues.TrianglesType;
                    whiteTriangles++;
                }
                else if (randomFloat <= 45)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedSquareValue;
                    jewelType = ConstantValues.SquaresType;
                    redSquares++;
                }
                else if (randomFloat <= 85)
                {
                    jewelColor = ConstantValues.GreenColor;
                    jewelValue = ConstantValues.GreenOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    greenOctagons++;
                }
                else if (randomFloat <= 99)
                {
                    jewelColor = ConstantValues.BlueColor;
                    jewelValue = ConstantValues.BlueOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    blueOctagons++;
                }
                else if (randomFloat == 100)
                {
                    jewelColor = ConstantValues.RedColor;
                    jewelValue = ConstantValues.RedOctagonValue;
                    jewelType = ConstantValues.OctagonsType;
                    redOctagons++;
                }
                break;
                #endregion

        }

        JewelsBaseScript.JewelColor = jewelColor;
        JewelsBaseScript.JewelValue = jewelValue;
        JewelsBaseScript.JewelType = jewelType;
        gameManagerInstance.Gold += jewelValue;


        GameObject jewel = objectPoolerInstance.GetObject(JewelTag);
        jewel.SetActive(true);
        jewel.transform.position = pos;

        GameObject pointOnScreen = objectPoolerInstance.GetObject(PointOnScreenTag);
        pointOnScreen.SetActive(true);
        pointOnScreen.transform.position = pos;

        if (upgradesAndBuffsInstace.TwoHandedBuffActive)
        {
            GameObject jewel2 = objectPoolerInstance.GetObject(JewelTag);
            jewel2.SetActive(true);
            jewel2.transform.position = pos;

            GameObject pointOnScreen2 = objectPoolerInstance.GetObject(PointOnScreenTag);
            pointOnScreen2.SetActive(true);
            pointOnScreen2.transform.position = pos;
            gameManagerInstance.Gold += jewelValue;
        }

    }

    public void OnUpgradeMenuToggle(bool active)
    {
        this.enabled = !this.enabled;
    }

    public void UpgradePickAxe()
    {
        upgradesAndBuffsInstace.UpgradePickAxe(ref currentToolLevel);
    }
}