using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

	// Returns list of cumulative score, eg. score card
	public static List<int> ScoreCumulative(List<int> rolls){
		List<int> cumulativeScores = new List<int>();
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls)){
			runningTotal += frameScore; 
			cumulativeScores.Add(runningTotal);
		}

		return cumulativeScores;
	}

	// Returns list of  individual frame scores
	public static List<int> ScoreFrames(List<int> rolls){
		List<int> frameList = new List<int>();

		// Index i points to 2nd bowl of frame. Step through two frames and calculate
		for(int i =1; i < rolls.Count; i += 2){
			if(frameList.Count == 10){break;} // Prevents 11th frame

			if((rolls[i - 1] + rolls[i]) < 10){ // "open frame"
				frameList.Add(rolls[i-1] + rolls[i]);
			}

			if(rolls.Count - i <= 1){break;} // Avoid out of bounds

			if(rolls[i-1] == 10){ // Strike bonus
				i--; // Strike frame has one bowl
				frameList.Add(10 + rolls[i+1] + rolls[i+2]);
			} else if((rolls[i - 1] + rolls[i]) == 10){ // Spare bonus
				frameList.Add(10 + rolls[i+1]); 
			}
		}

		return frameList;
	}

}
