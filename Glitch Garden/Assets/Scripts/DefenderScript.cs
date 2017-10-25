using UnityEngine;
using System.Collections;

public class DefenderScript : MonoBehaviour {
	public int starCost = 100;
	private StarDisplayScript starDisplay;
	
	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplayScript>();
	}
	
	public void AddStars(int amount) {
		starDisplay.AddStars(amount);
	}
}