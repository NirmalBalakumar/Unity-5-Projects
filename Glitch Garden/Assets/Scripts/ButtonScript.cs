using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {
	
	public GameObject defenderPrefab;
	public static GameObject selectedDefender;
	
	private ButtonScript[] buttonArray;
	private Text costText;
	
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<ButtonScript>();
		costText = GetComponentInChildren<Text>();	
		if(!costText) {Debug.LogWarning (name + " has no cost");}
		
		costText.text = defenderPrefab.GetComponent<DefenderScript>().starCost.ToString();
	}
	
	void OnMouseDown() {
		//print (name + " pressed");
		foreach (ButtonScript thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
		//print (selectedDefender + " selected");
	}
}
