using UnityEngine;
using System.Collections;

public class KillController : MonoBehaviour {

    public float damge;
	// Use this for initialization
	void Start () {
        damge = 50;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "enemy")
        {
            EnemyController enemy = col.GetComponent<EnemyController>();
            if (enemy == null)
            {
                Debug.Log("Khong co Enemy nao vao cham");
                return;
            }
            else
            {
                enemy.Hit(damge);
            }
        }
    }

}
