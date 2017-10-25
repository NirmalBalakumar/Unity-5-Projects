using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManagerScript : MonoBehaviour {

	public bool recording = true;

	void Start () {

		}

	void Update () {
		if(CrossPlatformInputManager.GetButton("Fire1")) {
			recording = false;
		} else {
			recording = true;
		}
	}
}