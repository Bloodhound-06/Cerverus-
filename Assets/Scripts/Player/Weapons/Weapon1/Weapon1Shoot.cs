//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Weapon1Shoot : MonoBehaviour
{

    [Header("Private")]
    private GameObject hitObject; //the game object that gets hit by the raycast
    private Vector3 targetPos; //the position of the mouse
    private Vector3 firePoint; //the origin of the raycast


    [Header("Floats")]
    public float fireDelay; //the delay between when you can fire
    public float maxBullet; //the amount of bullets in a full magazine
    public float currentBullet; //the amount of bullet remaining in the magazine
    public float reloadTime; //the time it takes to reload

    [Header("Bools")]
    public bool CanFire; //can the player fire?

    [Header("References")]
    public GameObject aimPoint; //the position of where to fire
    public Transform firePosition; //the position of the gun
    public GameObject pm; //the pause menu
    public PausMenu pmS; //the pause menu script


    [Header("Keybinds")]
    public KeyCode reloadKey; //the keybind to reload
    public KeyCode shootKey; //the keybind to fire
    private void Start()
    {
        aimPoint = GameObject.Find("cursor"); //sets the aimpoint
        CanFire = true; //set can fire to true
        currentBullet = maxBullet; //sets current bullets to max

        pm = GameObject.Find("PauseMenu");
        pmS = pm.GetComponent<PausMenu>(); //gets the 
    }

    private void Update()
    {

        
        firePoint = new Vector3(firePosition.position.x, firePosition.position.y); //sets the fire point to the firepoint position
        targetPos = aimPoint.transform.position - transform.position; //sets the targeting posiotion to the mouse

        Debug.DrawRay(firePoint, targetPos * 1000, Color.red); //draws a red line in the editor where the raycast is

        if (Input.GetKeyDown(shootKey) && CanFire == true) //is the shoot key pressed down
        {
            CanFire = false; //sets can fire to false
            Shoot(); //calls shoot
            Invoke(nameof(ResetFire), fireDelay); //calls reset fire on a delay
        }


        if (Input.GetKey(reloadKey)) //if the reload key is pressed
        {
            CanFire = false; //sets can fire to false
            Invoke(nameof(Reload), reloadTime); //calls reload with a delay
        }

    }
    private void Shoot()
    {
        currentBullet--; //removes one bullet from current bullets
        RaycastHit2D hit = Physics2D.Raycast(firePoint, targetPos, 1000); //creates a raycast from player to aimpoint

        if (hit.collider != null && hit.collider.CompareTag("Enemy")) //if the raycast hits and if the hit target is a enemy
        {
            Debug.Log(hit.collider.name); //writes the name of the hit target
            hitObject = GameObject.Find(hit.collider.name); //gets the gameobject of the hit object
            hitObject.GetComponent<EnemyHealth>().Hit(10); //gets the healthscript of the hit object
        }
    }



    private void ResetFire()
    {
        if (currentBullet <= 0) //if current bullets är mindre än 1
        {
            CanFire = false; //sets can fire to 
        }
        else
        {
            CanFire = true; //sets can fire to true
        }
    }

    private void Reload()
    {
        currentBullet = maxBullet; //sets current bullets to max
        CanFire = true; //sets can fire to true
    }

    private void IsPaused()
    {
        if(pmS.paused)
        {
            CanFire = false;
        }
        else if (!pmS.paused)
        {
            CanFire = true;
        }
    }
}
