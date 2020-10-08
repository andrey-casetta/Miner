using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stones : MonoBehaviour
{
    [SerializeField]
    StonesScriptableObject stoneScriptableObj;

    SpriteRenderer spriteRenderer;
    int totalHealth = 10000;
    int healthPhase1 = 5000;
    int healthPhase2 = 3000;
    int healthPhase3 = 2000;
    int goldGiven = 1000;
    int hpLostWhenstrengthBuffActive = 3;
    int bonusMultiplierPreciousStonesActive = 3;

    [SerializeField]
    //Sprite[] sprites;

    int currentHealth;

    CapsuleCollider capsuleCollider;

    //MUDANÇA
    //variaveis para ajuste do colisor quando ocorrer alteraçao de sprite

    float colliderHeight1 = 28.54f;
    float colliderRadius1 = 10.6f;
    float colliderHeight2 = 24.51f;
    float colliderRadius2 = 7.87f;
    float colliderHeight3 = 19.69f;
    float colliderRadius3 = 5.4f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        totalHealth = stoneScriptableObj.maxHealth;
        healthPhase1 = stoneScriptableObj.phase1Health;
        healthPhase2 = stoneScriptableObj.phase2Health;
        healthPhase3 = stoneScriptableObj.phase3Health;

        currentHealth = totalHealth;
    }

    void Update()
    {
        if (currentHealth > healthPhase1 && spriteRenderer.sprite != stoneScriptableObj.stoneImages[0])
        {
            spriteRenderer.sprite = stoneScriptableObj.stoneImages[0];
            if (capsuleCollider.radius != colliderRadius1)
            {
                capsuleCollider.radius = colliderRadius1;
                capsuleCollider.height = colliderHeight1;
            }
        }
        else if (currentHealth <= healthPhase2 && currentHealth > healthPhase3 && spriteRenderer.sprite != stoneScriptableObj.stoneImages[1])
        {
            spriteRenderer.sprite = stoneScriptableObj.stoneImages[1];
            if (capsuleCollider.radius != colliderRadius2)
            {
                capsuleCollider.radius = colliderRadius2;
                capsuleCollider.height = colliderHeight2;
            }
        }
        else if (currentHealth <= healthPhase3 && spriteRenderer.sprite != stoneScriptableObj.stoneImages[2])
        {
            spriteRenderer.sprite = stoneScriptableObj.stoneImages[2];
            if (capsuleCollider.radius != colliderRadius3)
            {
                capsuleCollider.radius = colliderRadius3;
                capsuleCollider.height = colliderHeight3;
            }
        }
    }

    public void LosesHp(bool strengthBuffActive, bool preciousStonesActive)
    {
        if (!strengthBuffActive)
        {
            currentHealth--;
        }
        else
        {
            currentHealth -= hpLostWhenstrengthBuffActive;
        }

        if (currentHealth <= 0)
        {
            spriteRenderer.color = new Color(255, 255, 255, 0);
            capsuleCollider.enabled = false;

            if (!preciousStonesActive)
                Die();
            else
                Die(bonusMultiplierPreciousStonesActive);
        }
    }

    public void Die()
    {
        GameManager.instance.Gold += goldGiven;
    }

    public void Die(int bonusMultiplier)
    {
        GameManager.instance.Gold += goldGiven * bonusMultiplier;
        //bonusMultiplier += bonusMultiplier * 3;
    }

}
