using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveling : MonoBehaviour
{
    
    public float damageLevel = 0, healthLevel = 0, armorLevel = 0;

    private void Start()
    {
        if (PlayerPrefs.GetFloat("damageLevel") != 0)
        {
            damageLevel = PlayerPrefs.GetFloat("damageLevel");
        }

        if (PlayerPrefs.GetFloat("healthLevel") != 0)
        {
            healthLevel = PlayerPrefs.GetFloat("healthLevel");
        }
        
        if (PlayerPrefs.GetFloat("armorLevel") != 0)
        {
            armorLevel = PlayerPrefs.GetFloat("armorLevel");
        }
    }
    public void IncreaseDamage(float value)
    {
        damageLevel += value;
        PlayerPrefs.SetFloat("damageLevel", damageLevel);
    }

    public void Increasehealth(float value)
    {
        healthLevel += value;
        PlayerPrefs.SetFloat("healthLevel", healthLevel);
    }

    public void IncreaseArmor(float value)
    {
        armorLevel += value;
        PlayerPrefs.SetFloat("armorLevel", armorLevel);
    }
}