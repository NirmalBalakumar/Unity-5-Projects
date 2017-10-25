using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour {

	public float standingThreshold;

	private GameObject floor;

	void Start () {
		floor = GameObject.Find("Floor");

	}

	void Update () {
		IsStanding();
	}

	public bool IsStanding () {
		float angle = Quaternion.Angle(transform.rotation, floor.transform.rotation);
		if(angle > standingThreshold) {
			//print (name +" is Down");
			return false;
		}
		return true;

		/* 
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(rotation.InEuler.x);
		float tiltInZ = Mathf.Abs(rotation.InEuler.z);

		if(tiltInX , standingThreshold && tiltInZ < standingThreshold) {
			return true;
		}
		else return false;
		*/
	}
}