using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayScript : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRolls (List <int> rolls) {
		string scoresString = FormatRolls(rolls);
		for(int i =0; i<scoresString.Length; i++) {
			rollTexts[i].text = scoresString[i].ToString();
		}
	}

	public void FillFrames (List<int> frames) {
		for(int i =0; i<frames.Count; i++) {
			frameTexts[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls (List <int> rolls) {
		string output = "";

		for(int i = 0; i < rolls.Count; i++) {
			int box = output.Length +1;														//output.length can also be used to track the bowl number

			if(rolls[i] == 0) {
				output += "-";																			//Zero is always "-"
			}
			else if( (box % 2 == 0 || box == 21) && rolls[i-1] + rolls [i] ==10 ) {
				output += "/";																			//SPARE
			}
			else if(rolls[i] == 10 && box < 19) {					
				output += " X";																	//STRIKE - X with <space>
			} 
			else if(rolls[i] == 10) {
				output += "X";																//For last frame X- without <space>
			}
			else {
				output += rolls[i].ToString();													//OPEN Bowl
			}
		}
		return output;
	}
}