using UnityEngine;
using System.Collections;

public class FollowEnemy : MonoBehaviour {

	// Use this for initialization
    //Lấy transform của enemy. Xong cho transform của thanh máu chạy theo.
    public Transform enemy;
    public Vector3 offset; //Này giống giống như là vận tốc. Mà muốn biết nó giống gì thì chạy thử rồi biết.
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = enemy.position + offset;
	}
}
