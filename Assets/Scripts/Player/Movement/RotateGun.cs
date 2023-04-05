using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGun : MonoBehaviour
{
    public GameObject pm; //the pausemenu game object
    public PausMenu pmS; //the pausemenu script

    private Vector2 mousePos;
    private void Update()
    {
        pm = GameObject.Find("PauseMenu");
        pmS = pm.GetComponent<PausMenu>();

        if (!pmS.paused) //if the game is not paused
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets the voctor from the middle of screen to the cursor
            transform.up = mousePos - new Vector2(transform.position.x, transform.position.y); //rotates the player to the previous vector
        }
    }
}
