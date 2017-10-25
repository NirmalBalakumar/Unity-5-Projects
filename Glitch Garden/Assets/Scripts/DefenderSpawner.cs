using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	
	public Camera myCamera;
	
	private GameObject parent;
	private StarDisplayScript starDisplay;
	
	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplayScript>();
		parent = GameObject.Find("Defenders");
		if(!parent) {
			parent = new GameObject ("Defenders");
		}	
	}
	
	void OnMouseDown() {
		Vector2 rawPos = MouseClickToWorldPosition();
		Vector2 roundedPos = SnapToGrid (rawPos);
		GameObject defender = ButtonScript.selectedDefender;
		int defenderCost = defender.GetComponent<DefenderScript>().starCost;
		
		if(starDisplay.UseStars(defenderCost) == StarDisplayScript.Status.SUCCESS) {
			SpawnDefender (defender, roundedPos);
			return;
		}	Debug.LogWarning("Insufficient Stars");
	}

	void SpawnDefender (GameObject defender, Vector2 roundedPos){
		Quaternion zeroRotation = Quaternion.identity;
		GameObject newDef = Instantiate (defender, roundedPos, zeroRotation) as GameObject;
		newDef.transform.parent = parent.transform;
	}
	
	Vector2 MouseClickToWorldPosition () {
	/*	Vector2 mousePos = new Vector2();
		Vector3 worldPos = new Vector3();
		mousePos = Input.mousePosition;
		worldPos = Camera.main.ScreenToWorldPoint(mousePos);
		return worldPos; */
		
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f;
		
		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera);
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		return worldPos;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPos) {
		int newX =  Mathf.RoundToInt(rawWorldPos.x);
		int newY =  Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX, newY);
	}
}