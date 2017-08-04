using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] bowlDisplay = new Text[21];
	public Text[] frameScoreDisplay = new Text[10];

	// Use this for initialization
	void Start () {
		foreach(Text bowl in bowlDisplay){
			bowl.text = "";
		}
		foreach(Text frame in frameScoreDisplay){
			frame.text = "";
		}
	}

	public void FillBowls(List<int> bowls){
		string bowlString = FormatBowls(bowls);
		for(int i = 0; i < bowlString.Length; i++){
			bowlDisplay[i].text = bowlString[i].ToString();
		}
	}

	public void FillFrames(List<int> frames){
		for(int i = 0; i < frames.Count; i++){
			frameScoreDisplay[i].text = frames[i].ToString();
		}
	}

	public static string FormatBowls(List<int> bowls){
  		string output = "";

		for(int i = 0; i < bowls.Count; i++){
			int roll = output.Length + 1; // Score box 1 to 21
			if(roll % 2 == 0 && bowls[i-1] + bowls[i] == 10) {
				output += "/"; // Spare
			} else if(roll >= 19 && bowls[i] == 10){
				output += "X"; // Strike in frame 10
			} else if(bowls[i] == 10){
				output += "X "; // Strike
			} else if(bowls[i] == 0){
				output += "-  "; // Zero equals dash
			} else {
				output += bowls[i].ToString();
			}
		}
	
		return output;
	}
}
