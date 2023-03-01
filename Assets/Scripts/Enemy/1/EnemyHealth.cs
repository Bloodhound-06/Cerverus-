using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHP; //the current hp
    public float maxHP = 30; //the max hp
    private GameObject player; //the player gameobject
    //public ScoreCounter Sc;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //sets the player gameobject to the player
        player.GetComponents<ScoreCounter>(); //sets the scorecounter to the scroecounter
        currentHP = maxHP; //sets the current hp to max
    }
    public void Hit(float damageTaken) //creates the void and a float for the damage the object takes
    {
        currentHP -= damageTaken; //removes the damage to the hp

        if(currentHP <= 0) //if the hp i 0
            //Sc.IncreaseScore(100); //calls increase score in scorecounter
            Destroy(this.gameObject); //destroy the gameobject
            
    }
}
