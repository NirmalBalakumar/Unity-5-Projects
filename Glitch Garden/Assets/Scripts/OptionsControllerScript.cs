using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsControllerScript : MonoBehaviour 
{	
	public Slider volumeSlider, difficultySlider;
	public LevelManagerScript levelManager;
	
	private MusicManagerScript musicManager;
	
	void Start ()
	{
		musicManager = GameObject.FindObjectOfType<MusicManagerScript>();
		volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
		difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}
	
	void Update ()
	{
		musicManager.SetVolume (volumeSlider.value);
	}
	
	public void SaveAndExit()
	{
		PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
		PlayerPrefsManager.SetDifficulty(difficultySlider.value);
		levelManager.LoadLevel ("01a Start");
	}
	
	public void SetDefaults()
	{	volumeSlider.value = 0.8f;
		difficultySlider.value = 2f;
	}
}