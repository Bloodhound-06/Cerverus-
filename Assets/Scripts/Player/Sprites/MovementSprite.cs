using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSprite : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    private void Update()
    {
        transform.position = player.position;
    }
}
