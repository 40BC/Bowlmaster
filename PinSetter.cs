using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;

	private Animator animator;
	private Pin[] pins;
	private PinCounter pinCounter;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		pins = GameObject.FindObjectsOfType<Pin>();
		pinCounter = GameObject.FindObjectOfType<PinCounter>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerExit(Collider collider){
		Pin exitingPin = collider.gameObject.GetComponentInParent<Pin>();
		if(exitingPin){
			exitingPin.DestroyPin();
		}
	}

	public void SetTidyTrigger(){
		animator.SetTrigger("tidyTrigger");
	}

	public void SetResetTrigger(){
		animator.SetTrigger("resetTrigger");
	}

	public void RaisePins(){
		// Raise standing pins only
		foreach(Pin pin in pins){
			pin.Raise();
		}
	}

	public void LowerPins(){
		foreach(Pin pin in pins){
			pin.Lower();
		}
	}

	public void RenewPins(){
		// Instantiate New Pins
		Instantiate(pinSet, new Vector3(0f, 1.5f, 0f), Quaternion.identity);		
	}

	public void AnimateAction(ActionMaster.Action action){
		if(action == ActionMaster.Action.Tidy){
			SetTidyTrigger();
		} else if(action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset){
			SetResetTrigger();
			pinCounter.Reset();
		} else if(action == ActionMaster.Action.EndGame){
			throw new UnityException("Don't know how to end game yet");
		}
	}
}
