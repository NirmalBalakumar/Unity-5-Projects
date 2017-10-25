using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioSystemScript : MonoBehaviour {

	public AudioClip initialHeliCall;
	public AudioClip initialCallReply;

	private AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}

	void OnMakeInitialHeliCall () {
		audioSource.clip = initialHeliCall;
		audioSource.Play ();
		Invoke("InitialReply" , initialHeliCall.length + 1f);
	}

	void InitialReply () {
		audioSource.clip = initialCallReply;
		audioSource.PlayDelayed (initialHeliCall.length + 1f);
		BroadcastMessage ("OnDispatchHelicopter");
	}
}