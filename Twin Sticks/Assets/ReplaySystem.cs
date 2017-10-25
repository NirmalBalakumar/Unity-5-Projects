using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

	private const int bufferFrames = 100;
	private MyKeyFrame[] keyFrames = new MyKeyFrame [bufferFrames];
	private Rigidbody rigidBody;
	private GameManagerScript gameManager;

	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		gameManager = GameObject.FindObjectOfType<GameManagerScript> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(gameManager.recording) {
			Record ();
		} else {
			PlayBack ();
		}
	}

	void Record () {
		rigidBody.isKinematic = false;
		int frame = Time.frameCount % bufferFrames;
		float time = Time.time;
		//print ("Writing frame " + frame);
		keyFrames [frame] = new MyKeyFrame (time, transform.position, transform.rotation);
	}

	void PlayBack () {
		rigidBody.isKinematic = true;
		int frame = Time.frameCount % bufferFrames;
		//print ("Reading frame " + frame );
		transform.position = keyFrames [frame].position;
		transform.rotation = keyFrames [frame].rotation;
	}
}

/// <summary>
/// A Structure for storing Time, Rotation and Position.
/// </summary>
public struct MyKeyFrame {
	public float frameTime;
	public Vector3 position;
	public Quaternion rotation;

	public MyKeyFrame (float aTime, Vector3 aPosition, Quaternion aRotation) {
		frameTime = aTime;
		position = aPosition;
		rotation = aRotation;
	}
}