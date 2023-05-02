using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public HealthSystem hps;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //if the player colides with an object withe the enemy tag
        {
            hps.Damage(10); //invokes Damager inside the health system script for 10
        }
    }

}
