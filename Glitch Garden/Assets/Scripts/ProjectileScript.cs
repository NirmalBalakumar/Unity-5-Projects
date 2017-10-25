using UnityEngine;
using System.Collections;

public class ProjectileScript : MonoBehaviour {

	public float speed, damage;

	void Start () {
	}

	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime); 
	}
	
	void OnTriggerEnter2D (Collider2D collider) {
		AttackerScript attack = collider.gameObject.GetComponent<AttackerScript>();
		HealthScript health = collider.gameObject.GetComponent<HealthScript>();
		
		if (attack && health) {
			health.UnderAttack(damage);
			Destroy(gameObject);
		}
		/*	bool check = collider.GetComponent<AttackerScript>();
		if(check == true) {
		HealthScript health = collider.GetComponent<HealthScript>();
		health.UnderAttack(damage);
		Destroy (gameObject);
		}else return;	*/
	}
}