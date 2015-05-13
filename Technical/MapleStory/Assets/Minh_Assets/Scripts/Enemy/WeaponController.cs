using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour 
{      
    public GameObject shot;
    public Transform shotSpawn;
    
    //float timeShot;
    //float timeWait = 0.5f;

    public float fireRate;
    private float nextFire;

    void Start()
    {        
    }
	void Update () 
    {
        //timeShot += Time.deltaTime;

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, Quaternion.identity);
            //timeShot = 0;           
        }            
                       
	}
}
