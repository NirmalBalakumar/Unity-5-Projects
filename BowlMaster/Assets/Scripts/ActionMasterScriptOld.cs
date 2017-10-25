using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMasterScriptOld {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int[] bowls = new int[21];
	private int bowl = 1;

	public static Action NextAction (List<int> pinFalls) {
		ActionMasterScriptOld am = new ActionMasterScriptOld();
		Action currentAction = new Action();

		foreach(int pinFall in pinFalls) {
			currentAction = am.Bowl(pinFall);
		}
		return currentAction;
	}

	private bool Bowl21AwardedForSpare () {
		return (bowls [19-1] + bowls [20-1] ==10);
	}

	private bool Bowl21AwardedForStrike () {
		if(bowls [19-1] == 10) {
			return (bowls [19-1] + bowls [20-1] >=10);
		} return false;
	}

	private Action Bowl (int pins) {
		if(pins <0 || pins >10) {throw new UnityException ("Invalid number of Pins");}

		bowls [bowl-1] = pins;
		//Debug.Log("Bowl Number = " + bowl);
		if(bowl == 21) {
			return Action.EndGame;
		}

		if(pins ==10 && bowl >= 19) {
			bowl += 1;
			return Action.Reset;
		}

		if( bowl >= 19 && Bowl21AwardedForStrike()) { //19th Strike + 20th did'nt knock down all pins
			bowl += 1;
			return Action.Tidy;
		}
		else if(bowl >= 19 && Bowl21AwardedForSpare ()) { //19th did'nt knock down all pins + 20th Bowls Spare
			bowl += 1;
			return Action.Reset;
		} 
		else if (bowl == 20 && !Bowl21AwardedForSpare() ) {//19th did'nt knock down all pins + 20th No Spare
			return Action.EndGame;
		}

		if(bowl % 2 != 0) { //First Ball of Frame
			if( pins == 10) { //Bowling a Strike
				bowl +=2; 
				return Action.EndTurn;
				} 
			bowl += 1;
			return Action.Tidy;
		} 
		else if (bowl % 2 ==0) { //Second Ball of Frame
			bowl +=1;
			return Action.EndTurn;
		}

		throw new UnityException ("Not sure what Action to return!");
	}
}