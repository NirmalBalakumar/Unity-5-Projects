using UnityEngine;
using System.Collections;

public class LevelManagerScript : MonoBehaviour 
{	public float autoLoadNextLevelAfter;
	//public MusicManagerScript musicManger;

	void Start()
	{	if(autoLoadNextLevelAfter >0)
		{	Invoke("LoadNextLevel", autoLoadNextLevelAfter);	
		}
		else
		{	 //Debug.Log("AutolLoadLevel disabled");
		}

		//musicManger = GameObject.FindObjectOfType<MusicManagerScript>();
	}

	public void LoadLevel(string name)
	{	Debug.Log("Level load requested for :"+ name);
		Application.LoadLevel(name);
	}
	
	public void QuitRequest()
	{	Debug.Log("I want to quit!");
		Application.Quit();
	}
	
	public void LoadNextLevel()
	{	int currentLevel = Application.loadedLevel;
		Application.LoadLevel(currentLevel+1);
		//musicManger.LevelMusic(currentLevel+1);
	}
}