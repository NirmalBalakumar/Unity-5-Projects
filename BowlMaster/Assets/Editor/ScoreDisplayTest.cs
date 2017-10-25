using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTests {
	
	[Test]
	public void T00PassingTest () {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01Bowl1 () {
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual(rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T02Bowl2345612 () {
		int[] rolls = {2,3, 4,5, 6,1, 2};
		string rollsString = "2345612";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T03BowlX1 () {
		int[] rolls = {10, 1};
		string rollsString = " X1";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T04Bowl19 () {
		int[] rolls = {1, 9};
		string rollsString = "1/";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T05BowlX010 () {
		int[] rolls = {10, 0,10};
		string rollsString = " X-/";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T06Bowl010X () {
		int[] rolls = {0,10, 10};
		string rollsString = "-/ X";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T07SpareBonus2 () {
		int[] rolls = {1,2, 3,5, 5,5, 3,3, 7,1, 9,1, 6};
		string rollsString = "12355/33719/6";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T08StrikeBonus3 () {
		int[] rolls = { 1,2, 3,4, 5,4, 3,2, 10, 1,3, 3,4};
		string rollsString = "12345432 X1334";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T09MultiStrikes3 () {
		int[] rolls = { 10, 10, 2,3, 10, 5,3};
		string rollsString = " X X23 X53";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T10TestGutterGame () {
		int[] rolls = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0};
		string rollsString = "--------------------";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T11TestAllOnes () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1};
		string rollsString = "11111111111111111111";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T12TestAllStrikes () {
		int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,10,10};
		string rollsString = " X X X X X X X X XXXX";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}

	[Test]
	public void T13SpareInLastFrame () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,7};
		string rollsString = "1111111111111111111/7";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}
	
	[Test]
	public void T14StrikeInLastFrame () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,2,3};
		string rollsString = "111111111111111111X23";
		Assert.AreEqual (rollsString, ScoreDisplayScript.FormatRolls (rolls.ToList()));
	}
}