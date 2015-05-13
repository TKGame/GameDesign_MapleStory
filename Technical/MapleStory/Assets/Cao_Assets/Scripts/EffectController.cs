using UnityEngine;
using System.Collections;

public class EffectController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void StartEffect(Transform transfPos)
    {
        Instantiate(gameObject, transfPos.position, Quaternion.identity);
    }
    public void EndEffect(Transform transfPos)
    {
        Destroy(gameObject);
    }
}
