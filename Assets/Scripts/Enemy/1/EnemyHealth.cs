using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHP; //the current hp
    public float maxHP = 30; //the max hp
    public GameObject player; //the player gameobject
    public GameObject Es;
    public ScoreCounter Sc;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //sets the player gameobject to the player
        Es = GameObject.FindGameObjectWithTag("EventSystem"); //sets the player gameobject to the event system
        Sc = Es.GetComponent<ScoreCounter>(); //sets the Score counter to the score counter
        currentHP = maxHP; //sets the current hp to max
    }
    public void Hit(float damageTaken) //creates the void and a float for the damage the object takes
    {
        currentHP -= damageTaken; //removes the damage to the hp

        if(currentHP <= 0)//if the hp i 0
        {
            Sc.ScoreIncrease(100); //calls increase score in scorecounter
            Destroy(this.gameObject); //destroy the gameobject
        }
            
    }
}
