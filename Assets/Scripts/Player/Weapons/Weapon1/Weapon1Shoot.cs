//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon1Shoot : MonoBehaviour
{

    [Header("Private")]
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
    public GameObject hitObject; //the game object that gets hit by the raycast
    public GameObject invisiLaser; //the invisible laser
    public GameObject GunLaser; //the laser the gun fires
    public GameObject pm; //the pause menu
    public Transform firePosition; //the position of the gun
    public PausMenu pmS; //the pause menu script
    public TextMeshProUGUI ammoCounter; //the game object of the ammo counter text


    [Header("Keybinds")]
    public KeyCode reloadKey; //the keybind to reload
    public KeyCode shootKey; //the keybind to fire
    private void Start()
    {
        AmmoCounter(); //calls Ammo Counter

        GunLaser = GameObject.Find("Laser"); //gets the laser
        aimPoint = GameObject.Find("cursor"); //sets the aimpoint
        CanFire = true; //set can fire to true
        currentBullet = maxBullet; //sets current bullets to max
        
        pm = GameObject.Find("PauseMenu"); //gets the pause menu
        pmS = pm.GetComponent<PausMenu>(); //gets the pause menu script

        GunLaser.SetActive(false); //hides the laser
        AmmoCounter(); //calls Ammo Counter
    }

    private void Update()
    {
        
        firePoint = new Vector3(firePosition.position.x, firePosition.position.y); //sets the fire point to the firepoint position
        targetPos = aimPoint.transform.position - transform.position; //sets the targeting posiotion to the mouse


        Debug.DrawRay(firePoint, targetPos, Color.red); //draws a red line in the editor where the raycast is


        if (Input.GetKeyDown(shootKey) && CanFire && !pmS.paused) //is the shoot key pressed down, can fire is true and the game issnt paused
        {
            CanFire = false; //sets can fire to false
            Shoot(); //calls shoot
            Laser(); //calls laser
            LaserOn(); //calls laser on
            Invoke(nameof(ResetFire), fireDelay); //calls reset fire on a delay
            
        }


        if (Input.GetKey(reloadKey)) //if the reload key is pressed
        {
            currentBullet = 0; //sets the current bullets to 0
            CanFire = false; //sets can fire to false
            AmmoCounter(); //calls Ammo counter
            Invoke(nameof(Reload), reloadTime); //calls reload with a delay
        }

    }

    
    private void Shoot()
    {
        currentBullet--; //removes one bullet from current bullets
        AmmoCounter(); //calls ammo counter
        RaycastHit2D hit = Physics2D.Raycast(firePoint, targetPos, 1000); //creates a raycast from player to aimpoint
        Debug.Log(hit.collider.name); //writes the name of the hit target

        if (hit.collider != null && hit.collider.CompareTag("Enemy")) //if the raycast hits and if the hit target is a enemy
        {
            /*hitObject = GameObject.Find(hit.collider.name); //gets the gameobject of the hit object
            hitObject.GetComponent<EnemyHealth>().Hit(10); //gets the healthscript of the hit object*/
            hit.collider.gameObject.GetComponent<EnemyHealth>().Hit(10);
        }
    }

    private void LaserOn()
    {
        GunLaser.SetActive(true); //reveals the laser
    }


    private void ResetFire()
    {
        LaserOff(); //calls laser off

        if (currentBullet <= 0) //if current bullets are less than 1
        {
            CanFire = false; //sets can fire to 
        }
        else
        {
            CanFire = true; //sets can fire to true
        }
    }

    private void LaserOff()
    {
        GunLaser.SetActive(false); //hides the laser
    }

    private void Laser()
    {
            GunLaser.transform.SetPositionAndRotation(invisiLaser.transform.position, invisiLaser.transform.rotation); 
            //sets position of the laser
    }

    private void Reload()
    {
        currentBullet = maxBullet; //sets current bullets to max
        CanFire = true; //sets can fire to true
        AmmoCounter(); // calls ammo counter
    }

    private void IsPaused()
    {
        if(pmS.paused) //if paused is true then
        {
            CanFire = false; //sets can fire to false
        } 
        else if (!pmS.paused) //if paused is false then
        {
            CanFire = true; //sets can fire to true
        }
    }

    private void AmmoCounter()
    {
        if (currentBullet == 0) //if current bullets are 0
        {
            ammoCounter.color = Color.red; //sets the text color to red
            ammoCounter.text = ("Empty"); // sets the text to empty
        }
        else if(currentBullet < 6 && currentBullet > 0)
        {
            ammoCounter.color = Color.red; //sets the color to red
            ammoCounter.text = currentBullet.ToString(); //sets the text to the amount of remaining bullets
        }
        else if(currentBullet < 11 && currentBullet > 5)
        {
            ammoCounter.color = Color.yellow; //sets the color to yellow
            ammoCounter.text = currentBullet.ToString(); //sets the text to the amount of remaining bullets
        }
        else
        {
            ammoCounter.color = Color.white; //sets the color to white
            ammoCounter.text = currentBullet.ToString(); //sets the text to the amount of remaining bullets
        }
    }
}
