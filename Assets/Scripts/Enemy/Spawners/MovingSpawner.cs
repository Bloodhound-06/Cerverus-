using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSpawner : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(-12f, 11.5f);
        MoveDown();
    }

    public void MoveDown()
    {
        
        //MoveRight();
    }
    /*public void MoveRight()
    {
        if (transform.position.x != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(-15.5f, -10.5f), 5 * Time.deltaTime);
        }
        MoveUp();
    }
    public void MoveUp()
    {
        if (transform.position.y != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(12f, -10.5f), 5 * Time.deltaTime);
        }
        MoveLeft();
    }
    public void MoveLeft()
    {
        if (transform.position.x != 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(12f, 11.5f), 5 * Time.deltaTime);
        }
        MoveDown();
    }
*/}