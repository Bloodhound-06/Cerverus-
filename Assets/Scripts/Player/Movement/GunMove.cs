using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMove : MonoBehaviour
{
    public Transform player1;
    private void Update()
    {
        transform.position = player1.position; //sets the position of this object to the player
    }
}
