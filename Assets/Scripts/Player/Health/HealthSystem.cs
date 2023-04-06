using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public float currentHealth, MaxHealth = 100;
    //public Slider slider;

    private void Start()
    {
        currentHealth = MaxHealth; //set hp to max
        //slider.maxValue = MaxHealth; //set slider max to max hp
    }

    /*public void Update()
    {
        slider.value = currentHealth; //set slider value to hp
    }*/

    public void Heal(float heal)
    {
        currentHealth += heal; //add heal to hp

        if(currentHealth > MaxHealth) //if hp more then max hp
        {
            currentHealth = MaxHealth; //set hp to max hp
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage; //remove dmg from hp

        if(currentHealth < 0) //if hp = 0
        {
            SceneManager.LoadScene(2);
        }
    }
}
