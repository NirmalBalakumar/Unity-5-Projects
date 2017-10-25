using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BallScript))]
public class DragLaunch : MonoBehaviour {

	private BallScript ball;
	private Vector3	dragStart, dragEnd;
	private float startTime, endTime;

	void Start () {
		ball = GetComponent<BallScript>();
	}

	public void DragStart () {
		dragStart = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd () {
		dragEnd = Input.mousePosition;
		endTime = Time.time;

		float time = endTime - startTime;
		float distance = Vector3.Distance(dragStart,dragEnd);
		float speed = distance/time;

		Vector3 direction = dragEnd-dragStart;
		Vector3 velocity = new Vector3 (direction.x,0,speed);

		/*
		float dragDuration = endTime - startTime;

		float launchSpeedX = (dragEnd.x - dragStart.x)/ dragDuration;
		float launchSpeedZ = (dragEnd.y - dragStart.y)/ dragDuration;

		Vector3 velocity = new Vector3(launchSpeedX,0,launchSpeedZ);
		*/
		ball.Launch(velocity);
	}
}