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
    private void Start()
    {
        InvokeRepeating("ChooseSpawn", 2f, 40f);
        InvokeRepeating("ChooseSpawn", 4f, 40f);
        InvokeRepeating("ChooseSpawn", 6f, 40f);
        InvokeRepeating("ChooseSpawn", 8f, 40f);
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
    }
}