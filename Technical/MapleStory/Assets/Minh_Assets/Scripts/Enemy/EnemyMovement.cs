using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{

	public Vector3 speed;

	Animator anim;
	//Xác đinh xem va chạm bên nào(trái/phải), mặc định là đi từ trái qua
	bool isCollision = true;
	//Xác định va chạm với Player
	bool playerInRange;
	//Xoay enemy khi nó đụng gạch
	Vector3 localScale;
	void Start () 
	{
		localScale = transform.localScale;
		anim = GetComponent<Animator>();
	}
	//Hàm này được gọi khi có va chạm giữa 2 Object(Một trong 2 là Triger)
	void OnTriggerEnter2D(Collider2D other) 
	{
		//Nếu va chạm với Object có tag là "Map"
		if (other.tag == "Map") 
		{
			//Chiều đi đang là trái qua phải
			if (isCollision == true) 
			{
				//Cho Object đi ngược lại
				speed *= -1;
				//Xoay Object
				localScale.x *= -1.0f;
				isCollision = false;
			}
			else 
			{
				speed *= -1;
				localScale.x *= -1.0f;
				isCollision = true;
			}
		}

		if (other.tag == "Player")
			playerInRange = true;
	}
	void OnTriggerExit2D(Collider2D other) 
	{
		if (other.tag == "Player")
			playerInRange = false;
	}

	void Move()
	{
		gameObject.transform.Translate (speed * Time.deltaTime);
		transform.localScale = localScale;
	}

	void Update () 
	{
		Move ();
		//Nếu có va chạm với Player thì chuyển sang trạng thái Attack
		if (playerInRange)
			anim.SetBool ("IsAttack",true);
		else 
			anim.SetBool ("IsAttack",false);

	}	

}
