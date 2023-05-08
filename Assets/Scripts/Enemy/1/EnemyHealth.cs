using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Variables")]
    public float currentHP; //the current hp
    public float maxHP = 30; //the max hp

    [Header("References")]
    public GameObject player; //the player gameobject
    public GameObject Es; //The event system Gameobject
    public ScoreCounter Sc; //the scorecounter Script
    public GameObject EnemyParent; //the paranet of this enemy
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //sets the player gameobject to the player
        Es = GameObject.FindGameObjectWithTag("EventSystem"); //sets the player gameobject to the event system
        Sc = Es.GetComponent<ScoreCounter>(); //sets the Score counter to the score counter
        maxHP = Random.Range(1, 60); //sets the max Hp between 1 and 60
        currentHP = maxHP; //sets the current hp to max
    }
    public void Hit(float damageTaken) //creates the void and a float for the damage the object takes
    {
        currentHP -= damageTaken; //removes the damage to the hp

        if(currentHP <= 0)//if the hp i 0
        {
            Sc.ScoreIncrease(maxHP); //calls increase score in scorecounter
            Destroy(EnemyParent); //destroy the gameobject
        }
            
    }
}
