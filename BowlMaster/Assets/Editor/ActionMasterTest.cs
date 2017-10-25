using UnityEngine;
using System;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls;
	private ActionMasterScript.Action endTurn = ActionMasterScript.Action.EndTurn;
	private ActionMasterScript.Action tidy = ActionMasterScript.Action.Tidy;
	private ActionMasterScript.Action reset = ActionMasterScript.Action.Reset;
	private ActionMasterScript.Action endGame = ActionMasterScript.Action.EndGame;

	[SetUp] 		//called everytime a test runs
	public void Setup () {
		pinFalls = new List<int>();
	}

	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1,1);		
	}

	[Test]
	public void T01OneStrikeReturnsEndTurn () {
	pinFalls.Add(10);
		Assert.AreEqual (endTurn, ActionMasterScript.NextAction (pinFalls));
	}

	[Test]
	public void T02Bowl8ReturnsTidy () {
		pinFalls.Add(8);
		Assert.AreEqual (tidy, ActionMasterScript.NextAction (pinFalls));
	}

	[Test]
	public void T03Bowl28SpareReturnEndTurn () {
		int[] rolls = {8,2};
		Assert.AreEqual (endTurn, ActionMasterScript.NextAction(rolls.ToList()));
	}

	[Test]
	public void T04CheckResetAtStrikeInLastFrame () {
		int[] rolls =  {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10 };
		Assert.AreEqual (reset, ActionMasterScript.NextAction(rolls.ToList()));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                
	}

	[Test]
	public void T05CheckResetAtSpareInLastFrame () {
		int[] rolls =  {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,1,9 };
		Assert.AreEqual (reset, ActionMasterScript.NextAction(rolls.ToList()));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
	}

	[Test]
	public void T06YouTubeRollsEndInEndGame () {
		int[] rolls = {8,2, 7,3, 3,4, 10, 2,8, 10, 10, 8,0, 10, 8,2,9};
		Assert.AreEqual (endGame, ActionMasterScript.NextAction(rolls.ToList()));
	}

	[Test]
	public void T07GameEndsAtBowl20 () {
		int[] rolls =  {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1 };
		Assert.AreEqual (endGame, ActionMasterScript.NextAction(rolls.ToList()));
	} 

	[Test]
	public void T08BowlsStrikeAt19And5At20ReturnsTidy () {
		int[] rolls =  {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,5};
		Assert.AreEqual (tidy, ActionMasterScript.NextAction(rolls.ToList()));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      
	}

	[Test]
	public void T09BowlsStrikeAt19And0At20ReturnsTidy () {
		int[] rolls =  {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,0 };
		Assert.AreEqual (tidy, ActionMasterScript.NextAction(rolls.ToList()));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           
	}    

	[Test]
	public void T10NathanBowlIndexTest () {
		int[] rolls =  {0,10, 5,5 };
		Assert.AreEqual (endTurn, ActionMasterScript.NextAction(rolls.ToList()));
	}  

	[Test]
	public void T11Dondi10thFrameTurkey () {
		int[] rolls =  {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1,10,10,10 };
		Assert.AreEqual (endGame, ActionMasterScript.NextAction(rolls.ToList()));                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
	}                                   
}