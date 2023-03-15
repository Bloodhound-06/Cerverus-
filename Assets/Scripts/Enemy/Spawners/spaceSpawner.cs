using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spaceSpawner : MonoBehaviour
{
    public GameObject enemy1;
    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemy1);
        }
    }
}
