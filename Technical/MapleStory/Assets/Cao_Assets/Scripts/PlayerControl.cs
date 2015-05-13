using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public float speed;
	private Animator anim;					// Reference to the player's animator component.
    public float HP;
    public float damge;
    public float amor;
    //reset dame Amount
    private PlayerHealth playerHealth;
    private Rigidbody2D rigid;
    private bool facingRight = true;
    public bool jump;
    public GameObject heroDie;
    public GameObject bullet;
    public GameObject healthOBj;
    public Transform transfBullet;
    public bool isJumb = false;
    public float moveForce = 365f;			// Amount of force added to move the player left and right.
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    private Transform groundCheck;
    private bool grounded = false;
    void Awake()
    {
        
        playerHealth = GameObject.Find("Health").GetComponent<PlayerHealth>();
        groundCheck = transform.Find("groundCheck");
        anim = GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        damge = 10;
        amor = 10;
        jump = false;
        facingRight = false;
    }

	void Update()
	{
        if (HP <= 0)
        {
            Die();
        }
        playerHealth.UpdateHealth(HP);

        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            isJumb = true;
        }
	}


	void FixedUpdate ()
	{
        Move();
        Shoot();
	}
    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("speed", Mathf.Abs(h));
        if (h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);
        if (Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
            GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (h > 0 && facingRight)
            Flip();
        else if (h < 0 && !facingRight)
            Flip();
        if (isJumb)
        {
            anim.SetTrigger("jumb");
            // Add a vertical force to the player.
            GetComponent<Rigidbody2D>().AddForce(new Vector2(1.0f, jumpForce));
            // Make sure the player can't jump again until the jump conditions from Update are satisfied.
            isJumb = false;
        }
 
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            if (!facingRight)
            {
                GameObject _bullet = Instantiate(bullet, transfBullet.position, Quaternion.identity) as GameObject;
                _bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                GameObject _bullet = Instantiate(bullet, transfBullet.position, Quaternion.identity) as GameObject;
                _bullet.GetComponent<BulletController>().Move();
            }
            
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

    public void Hit(float damge)
    {
        HP -= damge;
    }
    public void Die()
    {
        Debug.Log("Player da hi sinh");
        //Instantiate(heroDie, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            Debug.Log("Da va cham");
        }
    }

}
