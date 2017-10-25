using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour 
{	public float health;

	public void UnderAttack(float damage)
	{	health -= damage;
		//Debug.Log("Health : " + health);
		if(health <= 0)
		{	//trigger die animation
			DestroyObject ();
		}
	}
	
	public void DestroyObject()
	{	Destroy(gameObject);	
	}
}