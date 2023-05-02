
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Game Objects")]
    private GameObject player; //the player gameobject

    [Header("Floats")]
    public float movementSpeed = 1; //the standard movementspeed of the monster

    private void Start()
    {
        movementSpeed = Random.Range(0.2f, 2f);//sets the movement speed to between 0.2-2 times the normal speed

        player = GameObject.Find("Player"); //sets the player gameobject to the player
    }

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime); //moves the monster to the position of the player
    }
}