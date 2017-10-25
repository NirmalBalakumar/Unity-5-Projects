using UnityEngine;
using System.Collections;

[RequireComponent (typeof(AttackerScript))]
public class FoxScript : MonoBehaviour 
{	private AttackerScript attacker;
	private Animator animate;
	private AudioSource audioSource;

	void Start () 
	{	attacker = GetComponent<AttackerScript>();
		animate = GetComponent<Animator>();
		audioSource = GetComponent<AudioSource>();
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{	GameObject obj = collider.gameObject;
		if(!obj.GetComponent<DefenderScript>())
		{	return;
		} 
		if(obj.GetComponent<StoneScript>())
		{	animate.SetTrigger("JumpTrigger");
			audioSource.Play ();
		}
		else
		{	animate.SetBool("AttackMode", true);
			attacker.Attack(obj);		
		}
		//Debug.Log("Fox collided with " + collider);
	}
}