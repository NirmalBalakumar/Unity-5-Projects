using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimerScript : MonoBehaviour {
	
	public float levelSeconds;
	
	private Slider progressBar;
	private LevelManagerScript levelManager;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;
	
	void Start () {
		progressBar = GetComponent<Slider>();
		levelManager = GameObject.FindObjectOfType<LevelManagerScript>();
		audioSource = GetComponent<AudioSource>();
		
		WinLabel ();
	}

	void Update () {
		if(progressBar.value <1) {
			progressBar.value += (1/levelSeconds)*Time.deltaTime;
		}
		else if(!isEndOfLevel){
			HandleWinCondition ();
		}
	}

	void HandleWinCondition (){
		DestroyAllTaggedObjects();
		Invoke ("LoadNextLevel", audioSource.clip.length);
		audioSource.Play ();
		isEndOfLevel = true;
		winLabel.SetActive (true);
	}

//Destroys all objects with DestroyOnWin Tag
	void DestroyAllTaggedObjects() {
		GameObject[] toDestroyArray;
		toDestroyArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
		foreach(GameObject thisObject in toDestroyArray) {
			Destroy (thisObject);
		}		
	}

	void WinLabel () {
		winLabel = GameObject.Find ("WinLabel");
		winLabel.SetActive (false);
		if (!winLabel) {
			Debug.LogWarning ("WinLabel GameObject Missing");
		}
	}
		
	void LoadNextLevel () {
		levelManager.LoadNextLevel();
	}
}