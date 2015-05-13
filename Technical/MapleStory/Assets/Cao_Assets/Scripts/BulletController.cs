using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start () {
        rigid = gameObject.GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}
    public void Move()
    {
        rigid.velocity = new Vector2(speed, 0);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
