using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AttackerScript))]
public class LizardScript : MonoBehaviour 
{	private AttackerScript attacker;
	private Animator animate;
	
	void Start () 
	{	attacker = GetComponent<AttackerScript>();
		animate = GetComponent<Animator>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{	GameObject obj = collider.gameObject;
		if(!obj.GetComponent<DefenderScript>())
		{return;
		}
		animate.SetBool("AttackMode", true);
		attacker.Attack(obj);	
	}
}