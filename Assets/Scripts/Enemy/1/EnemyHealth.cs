using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    private void Start()
    {
        currentHP = maxHP;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Hit(50);
        }
    }

    public void Hit(float damageTaken)
    {
        currentHP -= damageTaken;
        if(currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
