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
    private bool facingRight;
    public bool jump;
    public GameObject heroDie;
    public GameObject bullet;
    public Transform transfBullet;
    void Awake()
    {
        playerHealth = GameObject.Find("Health").GetComponent<PlayerHealth>();
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
	}


	void FixedUpdate ()
	{
        Move();
        Shoot();
        Jump();
	}
    void Move()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            if (facingRight)
                Flip();
            anim.SetBool("isActackMove", true);
            rigid.velocity = new Vector2(-speed, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (!facingRight)
                Flip();
            anim.SetBool("isActackMove", true);
            rigid.velocity = new Vector2(speed, 0);
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            
            anim.SetBool("isActackMove", false);
            rigid.velocity = new Vector2(0, 0);
        }
 
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (!facingRight)
            {
                GameObject _bullet = Instantiate(bullet, transfBullet.position, Quaternion.identity) as GameObject;
                _bullet.GetComponent<BulletController>().speed = -1;
            }
            else
            {
                GameObject _bullet = Instantiate(bullet, transfBullet.position, Quaternion.identity) as GameObject;
                _bullet.transform.rotation = Quaternion.Euler(0, 180, 0);
                _bullet.GetComponent<BulletController>().speed = 1;
            }
            
        }
    }
	
	void Flip ()
	{
		
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
    void Jump()
    {
        if (jump == true)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 2, 0);
                jump = false;
            }
            
        }
    }
    public void Hit(float damge)
    {
        HP -= damge;
    }
    public void Die()
    {
        Instantiate(heroDie, transform.position, Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ground")
        {
            jump = true;
        }
    }

}
