using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightScript : MonoBehaviour {

	[Tooltip ("Number of minutes per second theat pass, try 60")]
	public float minutesPerSecond;

	void Update () {
			float angleThisFrame = Time.deltaTime / 360* minutesPerSecond;
			transform.RotateAround(transform.position, Vector3.forward, angleThisFrame);
	}
}
