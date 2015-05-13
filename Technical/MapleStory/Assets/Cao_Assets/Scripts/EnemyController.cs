using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float speed;
    public float HP;
    public GameObject enemyDie;
    public float damge = 50;
    private Animator amin;
    private bool playerInRange;//kiem tra va cham voi player
    private bool isMove;
    private GameObject playerControl;
    
    void Awake()
    {
        isMove = false ;
        amin = gameObject.GetComponent<Animator>();
        playerControl = GameObject.FindGameObjectWithTag("Player");
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        CheckPlayerRank();
        if (isMove == true)
            Move();
        if (HP <= 0)
        {
            Die();
        }
	}
    public void Hit(float _damge)
    {
        HP -= _damge;
    }
    public void Die()
    {
        Destroy(gameObject);
        //Instantiate(enemyDie, transform.position, Quaternion.identity);
    }
    void Move()
    {
        gameObject.transform.Translate(new Vector3(speed,0,0) * Time.deltaTime);
    }
    void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "bullet")
        {
            Debug.Log("Da va cham voi Bullet");
            BulletController _bullet = col.GetComponent<BulletController>();
            float _damge = _bullet.damgeBullet;
            Hit(_damge);
            _bullet.Destroy();
            
        }
        if (col.tag == "Player")
        {
            isMove = false;
            speed = 0;
            amin.SetBool("IsAttack", true);
            PlayerControl _player = col.GetComponent<PlayerControl>();
            _player.Hit(damge);
            //FinishActack();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Khong va cham voi Player");
            amin.SetBool("IsAttack", false);
            
        }
    }
    void FinishActack()
    {
        speed = -speed;
        Flip();
    }
    void CheckPlayerRank()
    {
        if(playerControl == null)
        {
            return;
        }
        float distance = Mathf.Abs(transform.position.x - playerControl.transform.position.x);
        
        if (distance < 5.0f)
        {
            isMove = true;
        }
    }
}
