using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMasterScript {

 	 //Returns a list of cumulative scores, like a normal score card.
	public 	static List<int> ScoreCumulative (List<int> rolls) {
		List<int> cumulativeScores = new List<int>();
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}

		return cumulativeScores;
	}

	//Returns a list of individual frames scores, not cumulative.
	public static List<int> ScoreFrames (List<int> rolls) {

//		List<int> frames = new List<int> ();
//		int firstBowlOfFrame = 0, secondBowlOfFrame = 0, strikePoints = 0, sparePoints = 0, frameTotal = 0;
//		int bowlNumber = 0;
//		int spareIndex = 0, strikeIndex = 0;
//		bool strike = false;
//		bool spare = false;
//
//		for (int i = 0; i < rolls.Count; i++) {
//			if(frames.Count == 10) {break;}
//			bowlNumber += 1;
//
//			//Odd Number Bowl
//			if(bowlNumber % 2 != 0 && !strike) {
//				if(rolls[i] == 10) {						//In case of Strike
//					strikePoints = rolls[i];
//					strikeIndex = bowlNumber;
//					strike = true;
//				}
//					if (!strike) {
//					firstBowlOfFrame = rolls[i];				
//					}
//			} 
//			//Even number Bowl
//			else 	if(bowlNumber % 2 == 0 && !strike) {
//				secondBowlOfFrame = rolls[i];
//				if (firstBowlOfFrame + secondBowlOfFrame == 10) {		//In case of Spare
//					sparePoints = 10;
//					spareIndex = bowlNumber;
//					spare = true;
//				}
//				if (!spare) { 
//				frameTotal = firstBowlOfFrame + secondBowlOfFrame;
//				frames.Add(frameTotal);
//				}
//			}
//
//			//Spare points calculation
//			if(bowlNumber == (spareIndex + 1) && spare) {
//				frameTotal = sparePoints + rolls[i];
//				spareIndex = 0;
//				spare = false;
//				frames.Add(frameTotal);
//			}
//
//			//Strike points calculation
//			if(bowlNumber == (strikeIndex + 2) && rolls.Count - i >= 1 && strike) {
//				frameTotal = strikePoints + rolls[i-1] + rolls[i];
//				i-=2;
//				bowlNumber -=1;
//				strikeIndex = 0;
//				strike = false;
//				frames.Add(frameTotal);
//			}
//		}
//		return frames;

		List<int> frames = new List<int> ();

		for(int i = 1; i<rolls.Count; i+=2) {

			if(frames.Count == 10) {break;}		//Prevents 11th Frame score

			if( rolls[i-1] + rolls [i] < 10) {			//Normal "Open" Frame
				frames.Add(rolls[i-1] + rolls [i]);
			}

			if (rolls.Count - i <= 1) {break;}		//Insufficient look-ahead

			if (rolls[i-1] == 10) {
				i--;																	// Strike frame has 1 bowl per frame
				frames.Add(10 + rolls[i+1] + rolls[i+2]);		//STRIKE
			}
			else if ( rolls[i-1] + rolls [i] == 10) {		//SPARE
				frames.Add(10+ rolls[i+1]);
			}

		}
		return frames;
	}
}