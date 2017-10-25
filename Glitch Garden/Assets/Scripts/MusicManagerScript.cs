using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour 
{
	public AudioClip[] levelMusicChangeArray;

	private AudioSource music;
	private int currentMusicIndex, levelMusicIndex;
	private float volume;

	void Awake()
	{	DontDestroyOnLoad(gameObject);
		//Debug.Log("Dont Destroy on load: " + name);	
	}
	
	void Start()
	{	music = GetComponent<AudioSource>();
		volume = PlayerPrefsManager.GetMasterVolume();
		if(volume==0f) {
			music.volume = 0.8f;
		}
		else {
			music.volume = volume;
		}
	}	

	private void OnEnable () {
		SceneManager.sceneLoaded += OnSceneLoaded; //scubscribe
	}

	private void OnDisable () {
		SceneManager.sceneLoaded -= OnSceneLoaded; //scubscribe
	}
										
	/*public void LevelMusic(int level)
	{	AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log("LevelMusic" + level);
		if(thisLevelMusic)
		{	music.Stop();
			music.clip = thisLevelMusic;
			music.loop = true;
			music.Play();
		}
	}	*/
	private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
	{	levelMusicIndex = scene.buildIndex;
		AudioClip thisLevelMusic = levelMusicChangeArray[levelMusicIndex];
		print ("levelMusicIndex" + levelMusicIndex);
		//Debug.Log("LevelMusic" + thisLevelMusic);
		if(thisLevelMusic && levelMusicIndex != currentMusicIndex)
		{	music.Stop();
			music.clip = thisLevelMusic;
			music.loop = true;
			music.Play();
			currentMusicIndex = levelMusicIndex;
			print ("currentMusicIndex" + currentMusicIndex);
		}
	}
	
	public void SetVolume(float volume)
	{
		music.volume = volume;
	}
}