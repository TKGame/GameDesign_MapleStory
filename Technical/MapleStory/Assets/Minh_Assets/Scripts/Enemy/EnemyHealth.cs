using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{

	public float startingHealth = 100f;
    public float currentHealth;
    public GameObject healthParent;
    public Image health;   
    //public Slider healthSlider;
    public AudioClip deathClip;
    
    Animator anim;
    AudioSource enemyAudio;
    bool isDead;
    EnemyMovement enemyMovement;
    float temp = 0.0f;    

	void Start () 
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        enemyMovement = GetComponent<EnemyMovement>();
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
    {
        TakeDamage(temp);
	}
    public void TakeDamage(float amount)
    {       
        currentHealth -= amount;

        health.fillAmount = currentHealth / (float)100f;
        //healthSlider.value = currentHealth;
        
       // enemyAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {                        
            Death();
            Destroy(healthParent);
            //Destroy(gameObject); 
        }
    }


    void Death()
    {
        isDead = true;     

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();

        enemyMovement.enabled = false;
        
        DestroyObject(gameObject, 0.6f);
    }
}
