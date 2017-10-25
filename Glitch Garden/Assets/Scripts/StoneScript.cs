using UnityEngine;
using System.Collections;

public class StoneScript : MonoBehaviour {

	private Animator animate;
	
	void Start() {
		animate = GetComponent<Animator>();
	}
	
	void OnTriggerStay2D(Collider2D collider) {
		AttackerScript attacker = collider.gameObject.GetComponent<AttackerScript>();
		if(attacker) {
			animate.SetTrigger("UnderAttackTrigger");
		}
	}
}
