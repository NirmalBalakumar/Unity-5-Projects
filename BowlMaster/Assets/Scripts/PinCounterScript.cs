using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounterScript : MonoBehaviour {

	private Text pinCountDisplay;
	private GameManagerScript gameManager;

	private bool ballEnteredBox = false;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;

	void Start () {
		gameManager = GameObject.FindObjectOfType<GameManagerScript>();
		pinCountDisplay =GameObject.Find("Pin Count Display").GetComponent<Text>();
	}

	void Update () {
		pinCountDisplay.text= CountStanding().ToString();

		if(ballEnteredBox || gameManager.gutterBall) {
			UpdateStandingAndSettle();
			pinCountDisplay.color = Color.red;
		}
	}

	void OnTriggerEnter (Collider collider) {
		if(collider.GetComponent<BallScript>()) {
		ballEnteredBox = true;
		}
	}

	public void Reset () {
		lastSettledCount = 10;
	}

	void UpdateStandingAndSettle () {
		int currentStanding = CountStanding();
		if(currentStanding != lastStandingCount) {
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}
		float settleTime = 3f;
		if((Time.time - lastChangeTime)> settleTime) {
			PinsHaveSettled();
		}
	}

	int CountStanding () {
		int standingPins =0;
		PinScript[] pinScriptArray;
		pinScriptArray = GameObject.FindObjectsOfType<PinScript>();
		foreach(PinScript pin in pinScriptArray) {
			if(pin != null && pin.IsStanding()) {
			standingPins ++;
			}
		}
		//print ("Number of Standing Pins = " + standingPins);
		return standingPins;
	}

	void PinsHaveSettled () {
		int pinsStanding = CountStanding ();
		int pinsFallen = lastSettledCount- pinsStanding;
		lastSettledCount = pinsStanding;

		gameManager.Bowls(pinsFallen);

		lastStandingCount = -1;
		ballEnteredBox = false;
		pinCountDisplay.color = Color.green;
	}
}
