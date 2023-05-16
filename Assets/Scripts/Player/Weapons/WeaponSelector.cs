using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public Weapon1Shoot w1s;
    public float debugFloat;

    private void Start()
    {
        PlayerPrefs.SetFloat("SelectedWeapon", 1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PlayerPrefs.SetFloat("SelectedWeapon", 1);
            w1s.AmmoCounter();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PlayerPrefs.SetFloat("SelectedWeapon", 2);
            w1s.AmmoCounter();
        }

        debugFloat = PlayerPrefs.GetFloat("SelectedWeapon");
    }
}