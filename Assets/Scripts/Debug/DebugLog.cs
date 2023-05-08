using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DebugLog : MonoBehaviour
{
    [Header("References")]
    public GameObject spawner;
    public MovingSpawner movingSpawner;
    public TextMeshProUGUI spawnedEnemiesTXT;
    public TextMeshProUGUI repeatersTXT;

    public void Start()
    {
        spawner = GameObject.Find("Spawners");
        movingSpawner = spawner.GetComponent<MovingSpawner>();
    }

    public void Update()
    {
        spawnedEnemiesTXT.text = ("Spawned Enemies; " + movingSpawner.spawnedEnemies.ToString());
        repeatersTXT.text = ("Repeaters: " + movingSpawner.Repeaters.ToString());

    }
}
