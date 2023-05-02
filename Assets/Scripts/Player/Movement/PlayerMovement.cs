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
            ReverseAnimation();
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
            
        }
        

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

    public void ReverseAnimation()
    {
        Vector3 charachterScale = transform.localScale;
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            charachterScale.x = -1;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            charachterScale.x = 1;
        }

        transform.localScale = charachterScale;
    }
}