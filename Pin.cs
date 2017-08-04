using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold;
	public float distanceToRaisePins = 45f;

	private Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

 	}

	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;
		float rotationX = Mathf.Abs(rotationInEuler.x);
		float rotationZ = Mathf.Abs(rotationInEuler.z);
		if(rotationX < standingThreshold || rotationZ < standingThreshold){
			return true;
		} else {
			return false;
		}
	}

	public void DestroyPin(){
		Destroy(gameObject);
	}

	public void Raise(){
		// Raise standing pins only
		if(this != null && IsStanding()){
			transform.Translate(new Vector3(0, distanceToRaisePins, 0));
			transform.rotation = Quaternion.identity;
			rigidBody.useGravity = false;
		}
	}

	public void Lower(){
		if(this != null){
			transform.Translate(new Vector3(0, -distanceToRaisePins, 0));
			rigidBody.useGravity = true;
		}
	}
}
