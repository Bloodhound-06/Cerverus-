using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject player;
    public GameObject start;
    private void Start()
    {
        player = GameObject.Find("Player"); //sets the player reference
        start = GameObject.Find("StartPos"); //sets the start reference
        player.transform.position = start.transform.position; //sets player position to start;
    }
}
