using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterScript : MonoBehaviour {

	//private bool called = false;
	private Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}

	void OnDispatchHelicopter() {
		Debug.Log("Helicopter called");
		rigidBody.velocity = new Vector3 (0,0,50f);
		//called = true;
	}
}