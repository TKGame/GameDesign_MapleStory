using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    public float HP;
    public GameObject enemyDie;
    private Animator amin;

    void Awake()
    {
        amin = gameObject.GetComponent<Animator>();
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Hit(float _damge)
    {
        HP -= _damge;
    }
    public void Die()
    {
        Instantiate(enemyDie, transform.position, Quaternion.identity);
    }
    void Move()
    {
 
    }
}
