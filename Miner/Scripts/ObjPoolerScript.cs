using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPoolerScript : MonoBehaviour
{
    public static ObjPoolerScript instance;

    [SerializeField]
    private GameObject[] pooledObjs;

    [SerializeField]
    int spawnAmount = 20;

    //var used to verify if its needed to add one more item to the list
    private bool plusOne = true;

    private List<GameObject> objectList;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        objectList = new List<GameObject>();

        for (int i = 0; i < pooledObjs.Length; i++)
        {
            for (int j = 0; j < spawnAmount; j++)
            {
                GameObject obj = Instantiate(pooledObjs[i]) as GameObject;
                obj.SetActive(false);
                objectList.Add(obj);
            }
        }
    }

    public GameObject GetObject(string objTag)
    {
        if (objectList.Count > 0)
        {
            for (int i = 0; i < objectList.Count; i++)
            {
                if (!objectList[i].activeInHierarchy && objectList[i].CompareTag(objTag))
                {
                    return objectList[i];
                }
            }
        }

        if (plusOne)
        {
            for (int i = 0; i < pooledObjs.Length; i++)
            {
                if (pooledObjs[i].CompareTag(objTag))
                {
                    GameObject obj = Instantiate(pooledObjs[i]) as GameObject;
                    objectList.Add(obj);
                    return obj;
                }
            }
        }
        return null;
    }
}
