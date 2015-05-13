using UnityEngine;
using System.Collections;

public class PlayerController_Tobi : MonoBehaviour {

    // vận tốc 
    public float moveSpeed = 0.0f;

    //
    public bool facingRight = true;

    public bool isJumb = false;


    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;

    private Transform groundCheck;
    private bool grounded = false;
    private Animator anim;

	// Use this for initialization
	void Awake () {
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //Debug.Log(grounded);

        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed,0.0f);
        //}
        //else if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, 0.0f);
        //}

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isJumb = true;
        }
	}

    void FixedUpdate()
    {
        // Cache the horizontal input.
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(h));
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            // ... add a force to the player.
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            // ... set the player's velocity to the maxSpeed in the x axis.
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (h > 0 && !facingRight)
            // ... flip the player.
            Flip();
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (h < 0 && facingRight)
            // ... flip the player.
            Flip();

        if (isJumb)
        {
            // Set the Jump animator trigger parameter.
            anim.SetTrigger("jumb");

            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, jumpForce));

            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            isJumb = false;
        }
    }

    void Flip()
    {
        // Switch the way the player is labelled as facing.
        facingRight = !facingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
