using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leveling : MonoBehaviour
{
    
    public float damageLevel, healthLevel, armorLevel;

    private void Start()
    {
        damageLevel = PlayerPrefs.GetFloat("damageLevel");
        healthLevel = PlayerPrefs.GetFloat("healthLevel");
        armorLevel = PlayerPrefs.GetFloat("armorLevel");
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