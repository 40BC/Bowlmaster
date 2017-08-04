using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreDisplayTest {

	[Test]
	public void T00PassingTest() {
		// Use the Assert class to test conditions.
		Assert.AreEqual(1, 1);
	}

	[Test]
	public void Test01Bowl(){
		int[] rolls = {1};
		string rollsString = "1";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatBowls(rolls.ToList()));
	}

	[Test]
	public void Test02BowlStrike(){
		int[] rolls = {10};
		string rollsString = "X";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatBowls(rolls.ToList()));
	}

	[Test]
	public void Test03BowlSpare(){
		int[] rolls = {8, 2};
		string rollsString = "/";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatBowls(rolls.ToList()));
	}

	[Test]
	public void Test04SpareFrameTen(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,3};
		string rollsString = "1111111111111111111/3";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatBowls(rolls.ToList()));
	}

	[Test]
	public void Test05StrikeFrameTen(){
		int[] rolls = {1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 1,1};
		string rollsString = "111111111111111111X11";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatBowls(rolls.ToList()));
	}

	[Test]
	public void Test06ZeroEqualsDash(){
		int[] rolls = {0};
		string rollsString = "- ";
		Assert.AreEqual(rollsString, ScoreDisplay.FormatBowls(rolls.ToList()));
	}
}
