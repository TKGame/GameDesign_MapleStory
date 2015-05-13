using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public float health;
	private SpriteRenderer healthBar;			// Reference to the sprite renderer of the health bar.
	private Vector3 healthScale;				// The local scale of the health bar initially (with full health).


   
	void Awake ()
	{
        health = 100;
        healthBar = gameObject.GetComponent<SpriteRenderer>();
	}

    void Start()
    {
        
    }
    void Update()
    {
        UpdateHealthBar();
    }

	void OnCollisionEnter2D (Collision2D col)
	{
        
	}

	void UpdateHealthBar ()
	{
		healthBar.color = Color.Lerp(Color.green, Color.red, 1 - health * 0.01f);
        healthBar.transform.localScale = new Vector3(health * 0.01f * 5, 1, 1);
	}
    public void UpdateHealth(float _health)
    {
        health = _health;
    }

    
}
