using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool inPlay = false;
	public bool readyToLaunch = true;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startingPosition;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		rigidBody.useGravity = false;
		startingPosition = transform.position;
	}

	void Update () {
	}

	public void Launch (Vector3 velocity) {
		if(! inPlay && readyToLaunch) {
			rigidBody.useGravity = true;
			rigidBody.velocity = velocity;
			audioSource.Play ();
			inPlay = true;
			readyToLaunch = false;
		}
	}

	public void MoveStart(float nudge) {
		if(! inPlay) {
			float x = Mathf.Clamp(transform.position.x + nudge , -50,50);
			float y = transform.position.y;
			float z = transform.position.z;
			transform.position = new Vector3(x,y,z);
		}
	}

	public void Reset () {
		inPlay = false;
		transform.position = startingPosition;
		transform.rotation = Quaternion.identity;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
}