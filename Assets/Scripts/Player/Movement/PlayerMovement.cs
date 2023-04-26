using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 5f; //the movement speed
    private Vector2 movement; //the movement input

    [Header("References")]
    public Rigidbody2D rb; //the ridgidbody on the player
    public GameObject pm; //the pausemenu game object
    public PausMenu pmS; //the pausemenu script
    public Animator animator;
    private void Update()
    {
        Inputs(); // calls inputs

        pm = GameObject.Find("PauseMenu");
        pmS = pm.GetComponent<PausMenu>();
    }

    private void FixedUpdate()
    {
        Movement(); //calls movement
    }


    private void Inputs()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); //gets the x input value
        movement.y = Input.GetAxisRaw("Vertical"); //gets the y input value
    }


    private void Movement()
    {
        if (movement.x != 0)
        {
            animator.SetFloat("Speed", Mathf.Abs(movement.x));
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(movement.y));
        }
        

        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement); //moves the player to the wanted position
    }
}