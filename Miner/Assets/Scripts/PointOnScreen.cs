using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointOnScreen : MonoBehaviour
{
    private GameObject canvas;
    RectTransform rectTransform;

    private void OnEnable()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
        gameObject.transform.SetParent(canvas.transform);
        rectTransform = GetComponent<RectTransform>();
        rectTransform.localScale = new Vector3(1, 1, 1);
        gameObject.transform.GetChild(0).GetComponent<Text>().text = JewelsBaseScript.JewelValue.ToString();
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
