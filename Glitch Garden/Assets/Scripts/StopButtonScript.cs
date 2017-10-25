using UnityEngine;
using System.Collections;

public class StopButtonScript : MonoBehaviour {
	
	private LevelManagerScript levelManager;
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
	}
	
	void OnMouseDown () {
		levelManager.LoadLevel("01a Start");
	}
}
