using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    public Vector3 speed;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(speed * Time.deltaTime);
    }
}
