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
        AmmoCounter();

        GunLaser = GameObject.Find("Laser"); //gets the laser
        aimPoint = GameObject.Find("cursor"); //sets the aimpoint
        CanFire = true; //set can fire to true
        currentBullet = maxBullet; //sets current bullets to max
        
        pm = GameObject.Find("PauseMenu"); //gets the pause menu
        pmS = pm.GetComponent<PausMenu>(); //gets the pause menu script

        GunLaser.SetActive(false);
    }

    private void Update()
    {
        
        firePoint = new Vector3(firePosition.position.x, firePosition.position.y); //sets the fire point to the firepoint position
        targetPos = aimPoint.transform.position - transform.position; //sets the targeting posiotion to the mouse


        Debug.DrawRay(firePoint, targetPos, Color.red); //draws a red line in the editor where the raycast is


        if (Input.GetKeyDown(shootKey) && CanFire == true) //is the shoot key pressed down
        {
            CanFire = false; //sets can fire to false
            Shoot(); //calls shoot
            Laser();
            LaserOn();
            Invoke(nameof(ResetFire), fireDelay); //calls reset fire on a delay
            
        }


        if (Input.GetKey(reloadKey)) //if the reload key is pressed
        {
            currentBullet = 0;
            CanFire = false; //sets can fire to false
            Invoke(nameof(Reload), reloadTime); //calls reload with a delay
        }

    }

    
    private void Shoot()
    {
        currentBullet--; //removes one bullet from current bullets
        AmmoCounter();
        RaycastHit2D hit = Physics2D.Raycast(firePoint, targetPos, 1000); //creates a raycast from player to aimpoint

        if (hit.collider != null && hit.collider.CompareTag("Enemy")) //if the raycast hits and if the hit target is a enemy
        {
            Debug.Log(hit.collider.name); //writes the name of the hit target
            hitObject = GameObject.Find(hit.collider.name); //gets the gameobject of the hit object
            hitObject.GetComponent<EnemyHealth>().Hit(10); //gets the healthscript of the hit object
        }
    }

    private void LaserOn()
    {
        GunLaser.SetActive(true);
    }


    private void ResetFire()
    {
        LaserOff();

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
        GunLaser.SetActive(false);
    }

    private void Laser()
    {
            GunLaser.transform.SetPositionAndRotation(invisiLaser.transform.position, invisiLaser.transform.rotation);
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

    private void AmmoCounter()
    {
        if (currentBullet == 0)
        {
            ammoCounter.color = Color.red;
            ammoCounter.text = ("Empty");
        }
        else if(currentBullet < 6 && currentBullet > 0)
        {
            ammoCounter.color = Color.red;
            ammoCounter.text = currentBullet.ToString();
        }
        else if(currentBullet < 11 && currentBullet > 5)
        {
            ammoCounter.color = Color.yellow;
            ammoCounter.text = currentBullet.ToString();
        }
        else
        {
            ammoCounter.color = Color.white;
            ammoCounter.text = currentBullet.ToString();
        }
    }
}
