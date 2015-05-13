using UnityEngine;
using System.Collections;

public class FrontCheck : MonoBehaviour {
		
	void OnTriggerEnter2D(Collider2D col)
	{
		Debug.Log("attack");
		if (col.gameObject.tag == "Player") {
			Debug.Log("attack 2");
			BossController.isAttack2 = true;
		}
	}
}
