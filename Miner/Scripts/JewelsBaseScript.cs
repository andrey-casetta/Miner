using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JewelsBaseScript : MonoBehaviour
{

    private static string _jewelType;

    private static int _jewelValue;

    private static string _jewelColor;

    public static string JewelType
    {
        get
        {
            return _jewelType;
        }
        set
        {
            _jewelType = value;
        }
    }

    public static int JewelValue
    {
        get
        {
            return _jewelValue;
        }
        set
        {
            _jewelValue = value;
        }
    }

    public static string JewelColor
    {
        get
        {
            return _jewelColor;
        }

        set
        {
            _jewelColor = value;
        }
    }


    Rigidbody2D rg;
    SpriteRenderer spriteRenderer;
    Sprite sprite;


    private void OnEnable()
    {
        rg = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        transform.Rotate(0, 0, Random.Range(0, 360));
        spriteRenderer.sprite = Resources.Load("Sprites/" + JewelType + "/" + JewelColor, typeof(Sprite)) as Sprite;
        rg.velocity = Vector3.zero;
        rg.AddForce(ApplyForce());
    }

    private Vector3 ApplyForce()
    {
        float x = Random.Range(-50, 50);
        float y = Random.Range(20, 80);
        return new Vector3(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("DownLimit"))
        {
            Disable();
        }
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
