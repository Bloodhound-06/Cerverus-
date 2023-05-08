using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelector : MonoBehaviour
{
    public Weapon1Shoot w1s;
    public Weapon2Shoot w2s;

    private void Start()
    {
        Weapon1();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Weapon1();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Weapon2();
        }
    }

    public void Weapon1()
    {
        w1s.enabled = true;
        w2s.enabled = false;
    }

    public void Weapon2()
    {
        w1s.enabled = false;
        w2s.enabled = true;
    }

}