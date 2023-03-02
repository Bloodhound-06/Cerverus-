using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 5f;
    private Vector2 movement;

    [Header("References")]
    public Rigidbody2D rb;
    public GameObject pm;
    public PausMenu pmS;

    [Header("LookAtMouse")]
    private Vector2 mousePos;

    private void Update()
    {
        Inputs(); // calls inputs

        LookAtMouse(); //calls loock at mouse

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
        rb.MovePosition(rb.position + moveSpeed * Time.fixedDeltaTime * movement); //moves the player to the wanted position
    }

    
    private void LookAtMouse()
    {
        if (!pmS.paused)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //gets the voctor from the middle of screen to the cursor
            transform.up = mousePos - new Vector2(transform.position.x, transform.position.y); //rotates the player to the previous vector
        }
    }
}