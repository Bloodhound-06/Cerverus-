using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public float currentHealth, MaxHealth = 100;
    public Slider slider;
    public Animator animator;
    public PlayerMovement playerMovement;
    public bool isDead =false;

    private void Start()
    {
        currentHealth = MaxHealth; //set hp to max
        slider.maxValue = MaxHealth; //set slider max to max hp
    }

    public void Update()
    {
        slider.value = currentHealth; //set slider value to hp
    }

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
        animator.SetBool("TakeDamage", true);
        Invoke(nameof(ResetAnimation), 0.5f); //inokes reset animation ín 0.5 seconds

        if(currentHealth < 1) //if hp is less than 1
        {
            isDead = true; //sets isDead to true
            animator.SetBool("Die", true); //sets the animators bool: die to true
            Invoke(nameof(ChangeGameOverScene), 1.2f); //change game over scene in 1.2 seconds
        }
    }

    public void ResetAnimation()
    {
        animator.SetBool("TakeDamage", false); //sets the animators bool: take damage to flase
    }

    public void ChangeGameOverScene()
    {
        SceneManager.LoadScene(2); // loads scene 2

    }
}
