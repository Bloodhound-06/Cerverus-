using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    //the reference to the player
    private GameObject Player;

    public float movementSpeed;
    //the movementspeed of the enemy

    private float distanceX, distanceY;
    //the distance between the entety and the player

    public float attackRange;

    public bool canAttack;
    //if the entety can attack

    void Start()
    {
        Player = GameObject.Find("Player");
        //sets the player reference to the player

        canAttack = true;
    }

    void Update()
    {
        //if can attack is true call: Distance, To Attack
        if (canAttack == true)
        {
            Distance();
            ToAttack();
        }
    }

    private void FixedUpdate()
    {
        //if can attack is true call: Move Enemy
        if (canAttack == true)
        {
            MoveEnemy();
        }
    }

    private void MoveEnemy()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, movementSpeed * Time.deltaTime);
        // moves the enemy towards the player
    }

    private void Distance()
    {
        //calculates the distance bettwen the player and the entety
        distanceX = transform.position.x - Player.transform.position.x;
        distanceY = transform.position.y - Player.transform.position.y;
    }

    private void ToAttack()
    {
        //if distance x and y is less then 1, call attack
        if (distanceX >= -attackRange && distanceX <= attackRange && distanceY >= -attackRange && distanceY <= attackRange)
        {
            Attack();
        }
    }

    private void Attack()
    {
        //set the enteties position to the players position
        transform.position = Player.transform.position;
        canAttack = false;
        Invoke(nameof(CanAttack), 3);
    }

    private void CanAttack()
    {
        canAttack = true;
    }
}