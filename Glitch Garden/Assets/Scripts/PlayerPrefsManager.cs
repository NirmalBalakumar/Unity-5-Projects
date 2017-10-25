using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour 
{	
	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";
	
	public static void SetMasterVolume(float volume)
	{	if(volume>=0 && volume<=1)
		{	PlayerPrefs.SetFloat(MASTER_VOLUME_KEY,volume);
		}else
		{	Debug.LogError("Volume out of range");
		}
	}
	
	public static float GetMasterVolume()
	{	return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	public static void UnlockLevel(int level)
	{	if( level <= Application.levelCount - 1)
		{	PlayerPrefs.SetInt(LEVEL_KEY+ level.ToString() , 1);	//use 1 for true
		}else
		{ Debug.LogError("Level index out of range");
		}
	}
	
	public static bool IsLevelUnlocked(int level)
	{	if( level <= Application.levelCount-1)
		{	if(PlayerPrefs.GetInt(LEVEL_KEY+level.ToString()) == 1)
			{ return true;
			}else
			{ return false;
			}
		}else
		{ 	Debug.LogError("Level index out of range");
			return false;
		}
	}
	
/*	public static bool IsLevelUnlocked(int level)
	{	int levelValue = PlayerPrefs.GetInt(LEVEL_KEY+level.ToString());
		bool isLevelUnlocked = (levelValue == 1);
		
		if( level <= Application.levelCount-1)
		{	return isLevelUnlocked;
		}else
		{ 	Debug.LogError("Level index out of range");
			return false;
		}
	} */
	
	public static void SetDifficulty(float difficulty)
	{	if(difficulty>=1 && difficulty<=3)
		{	PlayerPrefs.SetFloat(DIFFICULTY_KEY,difficulty);
		}else
		{	Debug.LogError("Difficulty out of range");
		}
	}
	
	public static float GetDifficulty()
	{	return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
}
