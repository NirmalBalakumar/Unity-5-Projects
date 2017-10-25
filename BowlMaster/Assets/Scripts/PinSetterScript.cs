using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PinSetterScript : MonoBehaviour {
	public GameObject pinsPrefab;

	private PinScript[] pinScriptArray;
	private PinCounterScript pinCounter;
	private BallScript ball;
	private Animator animator;

	void Start () {
		ball = GameObject.FindObjectOfType<BallScript>();
		pinScriptArray = GameObject.FindObjectsOfType<PinScript>();
		pinCounter = GameObject.FindObjectOfType<PinCounterScript>();
		animator = GetComponent<Animator>();
	}

	void Update () {
		pinScriptArray = GameObject.FindObjectsOfType<PinScript>();
	}

	public void PerformAction (ActionMasterScriptOld.Action action) {
	//Controlling the Animations for the Swiper
		if(action == ActionMasterScriptOld.Action.Tidy) {
			animator.SetTrigger("tidyTrigger");
		} 
		else if(action == ActionMasterScriptOld.Action.EndTurn || action == ActionMasterScriptOld.Action.Reset ) {
			animator.SetTrigger("resetTrigger");
			pinCounter.Reset();
		}
		else if(action == ActionMasterScriptOld.Action.EndGame) {
			throw new UnityException ("Dont know how to end Game");	
		}
	}


	public void RaisePins () {
		//Debug.Log("Raise");
		float distanceToRaise = 40f;
		foreach(PinScript pin in pinScriptArray) {
			if(pin != null && pin.IsStanding()) {
				Rigidbody rigidBody = pin.GetComponent<Rigidbody>();
				rigidBody.useGravity = false;
				rigidBody.angularVelocity = Vector3.zero;
				rigidBody.velocity = Vector3.zero;
				pin.transform.rotation = Quaternion.Euler(Vector3.zero);
				pin.transform.Translate(0,distanceToRaise,0);
			}
		}
	}

	public void LowerPins () {
		//Debug.Log("Lower");
		foreach(PinScript pin in pinScriptArray) {
			if(pin != null) {
				Rigidbody rigidBody = pin.GetComponent<Rigidbody>();
				rigidBody.useGravity = true;
				rigidBody.angularVelocity = Vector3.zero;
				rigidBody.velocity = Vector3.zero;
				pin.transform.rotation = Quaternion.Euler(Vector3.zero);
				ball.readyToLaunch = true;
			}
		}
	}

	public void RenewPins ()  {
		//Debug.Log("Renew");
		Instantiate(pinsPrefab, new Vector3 (0,40,1829), Quaternion.identity);
		foreach(PinScript pin in pinScriptArray) {
			if(pin != null) {
				Rigidbody rigidBody = pin.GetComponent<Rigidbody>();
				rigidBody.useGravity = false;
				pin.transform.rotation = Quaternion.Euler(Vector3.zero);
			}
		}
	}
}