using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpawner : MonoBehaviour
{
    [Header("Transforms")]
    public Transform sl1; //the 1st position of the spawner
    public Transform sl2; //the 1st position of the spawner
    public Transform sl3; //the 1st position of the spawner
    public Transform sl4; //the 1st position of the spawner
    public GameObject enemy1; //the game object of the enemy
    [Header("Variables")]
    public float randomNumber; //the float for the random number
    public float spawnedEnemies; //the float of enemies spawned
    public float Repeaters = 4; //the float for the numbers of repeaters
    private void Start()
    {
        InvokeRepeating(nameof(ChooseSpawn), 5f, 20f); 
        //invokes Choose Spawn in 5 seconds and repeating every 20 seconds

        InvokeRepeating(nameof(ChooseSpawn), 10f, 20f); 
        //invokes Choose Spawn in 10 seconds and repeating every 20 seconds

        InvokeRepeating(nameof(ChooseSpawn), 15f, 20f); 
        //invokes Choose Spawn in 15 seconds and repeating every 20 seconds

        InvokeRepeating(nameof(ChooseSpawn), 20f, 20f); 
        //invokes Choose Spawn in 20 seconds and repeating every 20 seconds
    }

    public void ChooseSpawn()
    {
        randomNumber = Random.Range(1, 4); //sets random number to between 1 and 4

        if (randomNumber == 1) //if the random number is 1
        {
            Instantiate(enemy1, sl1); //instantiates enemy 1 at spawn location 1
        }
        else if (randomNumber == 2) //if the random number is 2
        {
            Instantiate(enemy1, sl2); //instantiates enemy 1 at spawn location 2
        }
        else if (randomNumber == 3) //if the random number is 3
        {
            Instantiate(enemy1, sl3); //instantiates enemy 1 at spawn location 3
        }
        else if (randomNumber == 4) //if the random number is 4
        {
            Instantiate(enemy1, sl4); //instantiates enemy 1 at spawn location 4
        }
        spawnedEnemies++; //adds 1 to spawned enemies

        if (spawnedEnemies == 5) //if 5 enemies has been spanwed
        {
            InvokeRepeating(nameof(ChooseSpawn), 2f, 20f); //invokes choose spawn
            spawnedEnemies = 0; //sets spawned enemies to 0
            Repeaters++; //adds 1 to repeaters
        }
    }
}