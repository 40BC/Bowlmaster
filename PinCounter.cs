using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public int lastStandingCount = -1;
	public bool ballLeftBox = false;

	private Text standingDisplayText;
	private GameManager gameManager;

	private float lastChangedTime;
	private int lastSettledCount = 10;

	// Use this for initialization
	void Start () {
		standingDisplayText = GameObject.Find("UI Canvas").GetComponentInChildren<Text>();
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplayText .text = "Standing Pins: " + CountStandingPins().ToString();

		// If ball has entered box, call CheckStanding()
		if(ballLeftBox){
			CheckStanding();
		}	
	}

	void OnTriggerExit(Collider collider){
		if(collider.gameObject.name == "Bowling Ball"){
			standingDisplayText.color = Color.red;
			ballLeftBox = true;
		}
	}

	void CheckStanding(){
		// Update lastStandingCount
		// Call PinsHaveSettled()
		int currentStanding = CountStandingPins();

		if(currentStanding != lastStandingCount){
			lastChangedTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f; // 3s to see if pins have settled
		if((Time.time - lastChangedTime) > settleTime){ // If last change > 3s ago
			PinsHaveSettled();
		}
	}

	void PinsHaveSettled(){
		// Update display to green
		// Count fallen pins
		int standing = CountStandingPins();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.Bowl(pinFall); 

		lastStandingCount = -1; // Indicates pins have settled and ball not back in box
		ballLeftBox = false; 
		standingDisplayText.color = Color.green;
	}

	int CountStandingPins(){
		int standingPins = 0;

		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if(pin != null && pin.IsStanding()){
				standingPins++;
			}
		}
		return standingPins;
	}

	public void Reset(){
		lastSettledCount = 10;
	}
}
