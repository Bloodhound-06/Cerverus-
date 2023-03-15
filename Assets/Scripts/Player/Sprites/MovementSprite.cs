using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSprite : MonoBehaviour
{
    [Header("Sprites")]
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;
    private Sprite activeSprite;

    [Header("References")]
    public SpriteRenderer SpriteRenderer;
    public Transform player;

    private void Start()
    {
        activeSprite = down;
    }
    private void Update()
    {
        transform.position = player.position;

        if(Input.GetKey(KeyCode.A))
        activeSprite = left;

        else if(Input.GetKey(KeyCode.D))
        activeSprite = right;

        else if(Input.GetKey(KeyCode.S))
        activeSprite = down;

        else if(Input.GetKey(KeyCode.W))
        activeSprite = up;

        SpriteRenderer.sprite = activeSprite;
    }
}
