using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpawner : MonoBehaviour
{
    [Header("Transforms")]
    public Transform sl1;
    public Transform sl2;
    public Transform sl3;
    public Transform sl4;
    public GameObject enemy1;
    [Header("Variables")]
    public float randomNumber;
    public float spawnedEnemies; 
    public float Repeaters = 4;
    private void Start()
    {
        InvokeRepeating(nameof(ChooseSpawn), 5f, 20f);
        InvokeRepeating(nameof(ChooseSpawn), 10f, 20f);
        InvokeRepeating(nameof(ChooseSpawn), 15f, 20f);
        InvokeRepeating(nameof(ChooseSpawn), 20f, 20f);
    }

    public void ChooseSpawn()
    {
        randomNumber = Random.Range(1, 4);

        if (randomNumber == 1)
        {
            Instantiate(enemy1, sl1);
        }
        else if (randomNumber == 2)
        {
            Instantiate(enemy1, sl2);
        }
        else if (randomNumber == 3)
        {
            Instantiate(enemy1, sl3);
        }
        else if (randomNumber == 4)
        {
            Instantiate(enemy1, sl4);
        }
        spawnedEnemies++;

        if (spawnedEnemies == 5)
        {
            InvokeRepeating(nameof(ChooseSpawn), 2f, 20f);
            spawnedEnemies = 0;
            Repeaters++;
        }

    }
}