using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private Ball ball;
	private PinSetter pinSetter;
	private ScoreDisplay scoreDisplay;

	private List<int> bowls  = new List<int>();

	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}

	public void Bowl(int pinFall){
		try{
			bowls.Add(pinFall);
			pinSetter.AnimateAction(ActionMaster.NextAction(bowls)); 
		} catch {
			Debug.LogWarning("Bowls() has an error!");
		}

		try{
			scoreDisplay.FillBowls(bowls);
			scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(bowls));
		} catch {
			Debug.LogWarning("scoreDisplay.FillRollCard() has an error!");
		}
		ball.Reset();
	}
}
