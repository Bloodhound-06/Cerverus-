using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float currentHP;
    public float maxHP;
    public GameObject player;
    public ScoreCounter Sc;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponents<ScoreCounter>();
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

            Sc.IncreaseScore(100);
        }
    }
}
