using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rigid;
    public float damgeBullet;

	// Use this for initialization
	void Start () {
        damgeBullet = 10;
        rigid = gameObject.GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update () {
	}
    public void Move()
    {
        speed = -speed;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
