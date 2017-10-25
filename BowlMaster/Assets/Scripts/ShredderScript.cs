using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShredderScript : MonoBehaviour {

	void OnTriggerExit (Collider collider) {
		if(collider.GetComponentInParent<PinScript>()) {
		Destroy(collider.transform.parent.gameObject);
		}
	}
}