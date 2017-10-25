using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {
	
	public GameObject[] attackerPrefabArray;
	public float difficultyFactor = 5; 	//5 lanes 
	
	void Start () {
	
	}
	
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray) {
			if(TimeToSpawn(thisAttacker)) {
				Spawn(thisAttacker);
			}
		}		
	}
	
	bool TimeToSpawn(GameObject attackerGameObject) {
		AttackerScript myAttacker = attackerGameObject.GetComponent<AttackerScript>();
		float secondsPerSpawn = myAttacker.spawnRate;
		float spawnsPerSecond = 1/secondsPerSpawn;
		
		if(Time.deltaTime > secondsPerSpawn){
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		// Setting difficulty by progressive increase in spawn rate
	/* GameTimerScript gameTimer = GameObject.FindObjectOfType<GameTimerScript>();
		difficultyFactor -= (5/gameTimer.levelSeconds)* Time.deltaTime; */
		
		float threshold = (spawnsPerSecond * Time.deltaTime) /difficultyFactor;
		return (Random.value < threshold);
	}
	
	void Spawn ( GameObject myGameObject) {
		GameObject newAttacker = Instantiate(myGameObject) as GameObject;
		newAttacker.transform.parent = transform; //assigning parent
		newAttacker.transform.position = transform.position; //relocating game object to parent's transform
	}
}