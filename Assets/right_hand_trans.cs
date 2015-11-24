using UnityEngine;
using System.Collections;

public class right_hand_trans : MonoBehaviour {
	public GameObject hand; 
	public static GameObject ball;
	public Rigidbody rb;
	public static bool isTouchingBall;
	public static string handLocationData;

	// Use this for initialization
	void Start () {
		handLocationData = "";
		isTouchingBall = false;
		ball = GameObject.Find ("ball");
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (hand.transform.position);
		///Debug.Log (ball.transform.position);
		if (Vector3.Distance (hand.transform.position, ball.transform.position) < .1f) {
			ball.transform.parent = hand.transform;
			isTouchingBall = true;
			rb.isKinematic = true;
		}
	
		if (isTouchingBall == true) {
			handLocationData += hand.transform.position;
		}
	}
}



