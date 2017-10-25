using UnityEngine;
using System.Collections;

public class LoseColliderScript : MonoBehaviour {
	
	private LevelManagerScript levelManager;
	private GameObject loseLabel;
	private AudioSource audioSource;
	
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
		audioSource = GetComponent<AudioSource>();
		
		LoseLabel ();
	}
	
	void OnTriggerEnter2D () {
		Invoke ("GameOver", audioSource.clip.length);
		audioSource.Play ();
		loseLabel.SetActive (true);
		DestroyAllTaggedObjects();
	}
	
	void GameOver (){
		levelManager.LoadLevel("03b Lose");
	}
	
	//Destroys all objects with DestroyOnWin Tag
	void DestroyAllTaggedObjects() {
		GameObject[] toDestroyArray;
		toDestroyArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
		foreach(GameObject thisObject in toDestroyArray) {
			Destroy (thisObject);
		}		
	}
	
	void LoseLabel () {
		loseLabel = GameObject.Find ("LoseLabel");
		loseLabel.SetActive (false);
		if (!loseLabel) {
			Debug.LogWarning ("LoseLabel GameObject Missing");
		}
	}
}