using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class StarDisplayScript : MonoBehaviour {
	
	public enum Status {SUCCESS, FAILURE};
	
	private int totalStars = 100;
	private Text starText;
	private AudioSource audioSource;
	
	void Start () {
		starText = gameObject.GetComponent<Text>();
		audioSource = GetComponent<AudioSource>();
		UpdateDisplay();
	}
	
	public void AddStars (int amount) {
		totalStars += amount;
		UpdateDisplay();
		audioSource.Play ();
	}
	
	public Status UseStars (int amount) {
		if(totalStars >= amount) {
			totalStars -= amount;
			UpdateDisplay();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
	
	private void UpdateDisplay() {
		starText.text = totalStars.ToString();
	}
}