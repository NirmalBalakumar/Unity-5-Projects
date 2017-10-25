using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public GameObject landingAreaPrefab;
	
	private bool respawn = false;
	private bool lastRespawnToggle = false;
	private Transform[] spawnPointsArray;

	void Start () {
		spawnPointsArray = GameObject.Find("Player Spawn Points").GetComponentsInChildren<Transform>();
	}

	void Update () {
		if(lastRespawnToggle != respawn) {
			Respawn();
			respawn = false;
		} 
		else {
			lastRespawnToggle = respawn;
		}
	}

	void Respawn () {
		int i = Random.Range(1, spawnPointsArray.Length);
		transform.position = spawnPointsArray[i].position;
	}

	void OnFindClearArea () {
		Invoke ("DropFlare" , 3f);
	}

	void DropFlare () {
		Instantiate (landingAreaPrefab, transform.position, transform.rotation);
	}
}