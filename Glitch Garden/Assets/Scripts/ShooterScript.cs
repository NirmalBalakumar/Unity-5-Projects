using UnityEngine;
using System.Collections;

public class ShooterScript : MonoBehaviour {
	public GameObject projectile, gun;
	public float fireRate;
	
	private GameObject parent;
	private Animator animator;
	private SpawnerScript mySpawnerLane;
	private AudioSource audioSource;
	
	void Start() {
		animator = GameObject.FindObjectOfType<Animator>();
		audioSource = GetComponent<AudioSource>();
		
		// Creates a parent if necessary
		parent = GameObject.Find("Projectiles");
		if(!parent) {
			 parent = new GameObject ("Projectiles");
		}
		
		SetMyLaneSpawner();
			print(mySpawnerLane);
	}
	
	void Update() {
		if(IsAttackerAheadInLane()) {
			animator.SetBool ("DefenceMode" , true);
		} else {
			animator.SetBool ("DefenceMode" , false);
		}
	}
	
	void SetMyLaneSpawner() {
		SpawnerScript[] spawnerArray = GameObject.FindObjectsOfType <SpawnerScript>();
		float lane = transform.position.y;
		foreach(SpawnerScript currentSpawner in spawnerArray) {
			if(currentSpawner.transform.position.y == lane ) {
				mySpawnerLane = currentSpawner;
				return;
				}
			}
		Debug.LogError(name+" cannot find enemies in " + lane);
	}
	
	bool IsAttackerAheadInLane() {
		// Exit if there are no attacekers
		if (mySpawnerLane.transform.childCount <= 0) {
			return false;
		}
		// If there are attackers, are they ahead ?
		foreach(Transform attackers in mySpawnerLane.transform) {
			if(attackers.transform.position.x > transform.position.x) {
				return true;
			}
		}
		//Attackers in lane, but behind us?
		return false;
	}
	
	private void FireGun() {	
		if(Random.value < fireRate) {
			GameObject newProjectile = Instantiate(projectile) as GameObject;
			newProjectile.transform.parent = parent.transform;
			newProjectile.transform.position = gun.transform.position;
			audioSource.Play ();
		}
	}
}