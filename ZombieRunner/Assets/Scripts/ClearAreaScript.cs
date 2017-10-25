using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearAreaScript : MonoBehaviour {

	private float timeSinceLastTrigger = 0f;
	private bool foundClearArea = false;

	void Update () {
		timeSinceLastTrigger += Time.deltaTime;
			if(timeSinceLastTrigger>1f && Time.realtimeSinceStartup > 10f && !foundClearArea) {
				SendMessageUpwards("OnFindClearArea");
				foundClearArea = true;
				Debug.Log ("Found area");
			}
	}

	void OnTriggerStay(Collider collider) {
		Debug.Log ("Colliding");
		if(collider.tag != "Player")	{
			timeSinceLastTrigger = 0f;
		}
	}
}