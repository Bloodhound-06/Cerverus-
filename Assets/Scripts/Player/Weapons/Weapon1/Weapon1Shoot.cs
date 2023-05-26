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
    public float fireDelay2 = 2; //the delay between when you can fire weapon number 2

    [Header("Bools")]
    public bool CanFire; //can the player fire?
    public bool canFire2 = true;//can weapon 2 fire

    [Header("References")]
    public GameObject aimPoint; //the position of where to fire
    public GameObject hitObject; //the game object that gets hit by the raycast
    public GameObject invisiLaser; //the invisible laser
    public GameObject GunLaser; //the laser the gun fires
    public GameObject pm; //the pause menu
    public GameObject Weapon2Bullet; //the bullet weapon 2 fire
    public Transform firePosition; //the position of the gun
    public Transform firePoint2; //the position of the second gun
    public Transform player2; //the player 2 game object
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
        currentBullet = maxBullet; //sets current bullets to max

        pm = GameObject.Find("PauseMenu"); //gets the pause menu
        pmS = pm.GetComponent<PausMenu>(); //gets the pause menu script

        GunLaser.SetActive(false); //hides the laser
        AmmoCounter(); //calls Ammo Counter
    }

    private void Update()
    {
        if (PlayerPrefs.GetFloat("SelectedWeapon") == 1)
        {
            if (Input.GetKeyDown(shootKey) && CanFire && !pmS.paused) //if the shoot key pressed down, can fire is true and the game issnt paused
            {
                CanFire = false; //sets can fire to false
                Shoot(); //calls shoot
                Laser(); //calls laser
                LaserOn(); //calls laser on
                Invoke(nameof(ResetFire), fireDelay); //calls reset fire on a delay

            }

            if (Input.GetKey(reloadKey) && currentBullet != 30) //if the reload key is pressed and the ammo issnt full
            {
                currentBullet = 0; //sets the current bullets to 0
                CanFire = false; //sets can fire to false
                AmmoCounter(); //calls Ammo counter
                Invoke(nameof(Reload), reloadTime); //calls reload with a delay
            }
        }
        else if (PlayerPrefs.GetFloat("SelectedWeapon") == 2)
        {
            if (Input.GetKeyDown(shootKey) && canFire2 == true && pmS.paused != true) //if the shoot key pressed down, can fire is true and the game issnt paused
            {
                Shoot(); //calls shoot
                canFire2 = false; //sets can fire 2 to false
                Invoke(nameof(ResetFire), fireDelay2); //calls reset fire on a delay
            }

            if (Input.GetKeyDown(reloadKey) && currentBullet != 30) // if the reload key is pressed and the amount of bullets
            {
                currentBullet = 0; //sets the current bullets to 0
                CanFire = false; //sets can fire to false
                AmmoCounter(); //calls Ammo counter
                Invoke(nameof(Reload2), reloadTime); //calls reload with a delay
            }
        }
        firePoint = new Vector3(firePosition.position.x, firePosition.position.y); //sets the fire point to the firepoint position
        targetPos = aimPoint.transform.position - transform.position; //sets the targeting posiotion to the mouse
        Debug.DrawRay(firePoint, targetPos, Color.red); //draws a red line in the editor where the raycast is

    }

    private void Shoot()
    {
        if (PlayerPrefs.GetFloat("SelectedWeapon") == 1)
        {
            currentBullet--; //removes one bullet from current bullets
            AmmoCounter(); //calls ammo counter
            RaycastHit2D hit = Physics2D.Raycast(firePoint, targetPos, 1000); //creates a raycast from player to aimpoint
            Debug.Log(hit.collider.name); //writes the name of the hit target

            if (hit.collider != null && hit.collider.CompareTag("Enemy")) //if the raycast hits and if the hit target is a enemy
            {
                hit.collider.gameObject.GetComponent<EnemyHealth>().Hit(10 * PlayerPrefs.GetFloat("damageLevel")); //gets the health script of the hit enemy and calls hit with a 10
            }
        }
        else if (PlayerPrefs.GetFloat("SelectedWeapon") == 2) //if the current weapon selekted is 2
        {
            Instantiate(Weapon2Bullet, firePoint2.position, player2.rotation);
            currentBullet -= 3;
            AmmoCounter();
            Invoke(nameof(ResetFire), fireDelay2);
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
            CanFire = false; //sets can fire to false
            canFire2 = false; //sets can fire to false
        }
        else

        {
            CanFire = true; //sets can fire to true
            canFire2 = true; //sets can fire to true
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

    public void Reload()
    {
        currentBullet = maxBullet; //sets current bullets to max
        CanFire = true; //sets can fire to true
        AmmoCounter(); // calls ammo counter
    }

    public void Reload2()
    {
        currentBullet = maxBullet; //sets current bullets to max
        CanFire = true; //sets can fire to true
        AmmoCounter(); // calls ammo counter
        ResetFire();
    }

    private void IsPaused()
    {
        if (pmS.paused) //if paused is true then
        {
            CanFire = false; //sets can fire to false
        }
        else if (!pmS.paused) //if paused is false then
        {
            CanFire = true; //sets can fire to true
        }
    }

    public void AmmoCounter()
    {
        if (currentBullet == 0) //if current bullets are 0
        {
            ammoCounter.color = Color.red; //sets the text color to red
            ammoCounter.text = ("Empty"); // sets the text to empty
        }
        else if (currentBullet < 6 && currentBullet > 0)
        {
            ammoCounter.color = Color.red; //sets the color to red
            ammoCounter.text = currentBullet.ToString(); //sets the text to the amount of remaining bullets
        }
        else if (currentBullet < 11 && currentBullet > 5)
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
