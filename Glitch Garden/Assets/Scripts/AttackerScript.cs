using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody2D))]
public class AttackerScript : MonoBehaviour {
	
	[Tooltip ("Average number of seconds between appearnaces")]
	public float spawnRate;
	
	private float currentSpeed;
	private GameObject currentTarget;
	private Animator animate;
	
	void Start()
	{	animate = GetComponent<Animator>();
	}

	void Update ()
	{	transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
		if(!currentTarget)
		{	animate.SetBool("AttackMode", false);
		}
	}
	
	public void SetSpeed(float speed)
	{	currentSpeed = speed;
	}
	
	//Puts the attacker into Attack Mode
	public void Attack(GameObject obj)
	{	currentTarget = obj;
	}
		
	//Called from Animator at the time of actual attack
	public void StrikeCurrentTarget (float damage)
	{	if(currentTarget)
		{	HealthScript Life = currentTarget.GetComponent<HealthScript>();
			if(Life)
			{	Life.UnderAttack(damage);
			}
		}
	}
}