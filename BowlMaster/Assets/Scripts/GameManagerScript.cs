using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript: MonoBehaviour {
	private List<int> rolls = new List<int>();
	private PinSetterScript pinSetter;
	private BallScript ball;
	private ScoreDisplayScript scoreDisplay;

	public bool gutterBall = false;

	void Start () {
		ball = GameObject.FindObjectOfType<BallScript>();
		pinSetter = GameObject.FindObjectOfType<PinSetterScript>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplayScript>();
	}

	void Update () {
		//Handling Gutter Ball scenario
		if(ball.transform.position.y < -2500  && ball.inPlay) {
			gutterBall = true;
			ball.Reset();
			//Debug.Log("Gutter Ball - Reset");
		}
	}

	public void Bowls (int pinFall) {
		try {
			rolls.Add (pinFall);
			ball.Reset();

			pinSetter.PerformAction (ActionMasterScriptOld.NextAction (rolls));
			}
		catch {
			Debug.LogWarning("Something went wrong in Bowl()");
		} 
		try {
			scoreDisplay.FillRolls (rolls);
			scoreDisplay.FillFrames(ScoreMasterScript.ScoreCumulative(rolls));
			}
		catch {
			Debug.LogWarning ("FillRollCard Failed");
		}
	}
}