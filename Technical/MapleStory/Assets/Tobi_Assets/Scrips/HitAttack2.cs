using UnityEngine;
using System.Collections;

public class HitAttack2 : MonoBehaviour {

	public float speed = 0.0f;
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left*Time.deltaTime*speed);
	}
}
