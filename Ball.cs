using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public bool ballLaunched = false;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private float ballPosX;
	private float ballPosZ;
	private Vector3 ballStartPosition;
	private Text leftPanelText;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		rigidBody.useGravity = false;
		ballStartPosition = transform.position;
		leftPanelText = GameObject.Find("UI Canvas").GetComponentInChildren<Text>();

	}

	public void Launch(Vector3 velocity){
		ballLaunched = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = new Vector3(velocity.x, velocity.y, velocity.z + 200f);
		audioSource.Play();
	}

	public void Reset(){
		// Resets ball after pins have settled
		leftPanelText.color = new Color(27, 0, 227);
		transform.position = ballStartPosition;
		transform.rotation = Quaternion.identity;
		rigidBody.useGravity = false;
		ballLaunched = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
	}
}