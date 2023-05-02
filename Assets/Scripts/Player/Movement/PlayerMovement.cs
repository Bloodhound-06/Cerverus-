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
    public HealthSystem hps;
    private void Update()
    {
        if (hps.isDead != true)
        {
            Inputs(); // calls inputs
            ReverseAnimation(); // calls reverse animation
        }
        else
        {
            movement.x = 0; // sets movement x to 0
            movement.y = 0; // sets movement y to 0
            
        }
        

        pm = GameObject.Find("PauseMenu"); // sets pm to pausemenu
        pmS = pm.GetComponent<PausMenu>(); // sets pms to the pausemenu script
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
        if (movement.x != 0) // if movement x issnt 0
        {
            animator.SetFloat("Speed", Mathf.Abs(movement.x)); // sets the animator float speed to movement x
        }
        else // else
        {
            animator.SetFloat("Speed", Mathf.Abs(movement.y)); // sets the animator float speed to movement y
        }
        

        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement); //moves the player to the wanted position
    }

    public void ReverseAnimation()
    {
        Vector3 charachterScale = transform.localScale; // creates charachterscale and sets it to transform localscale

        if(Input.GetAxisRaw("Horizontal") < 0) //if input axis horizontal is less than 0
        {
            charachterScale.x = -1; // sets the charachter x scale to -1
        }
        else if (Input.GetAxisRaw("Horizontal") > 0) // if input axis horizontal is more than 0
        {
            charachterScale.x = 1; // sets the charachter x scale to 1
        }

        transform.localScale = charachterScale; // sets the local scale to characheter scale
    }
}