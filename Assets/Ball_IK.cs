using UnityEngine;
using System.Collections;
using RootMotion.FinalIK;
using UnityEngine.UI;
using Microsoft.Kinect;

public class Ball_IK : MonoBehaviour {
	
	public InteractionObject BallIO;
	private InteractionManager handsmanage;
	public Vector3 holdOffset;
	
	private float holdWeight;
	private FullBodyBipedIK ik;
	public GameObject target;
	public Vector3 initballpos;
	public int score;
	public Text countText;
	public GameObject ballllll;
	public int pScore, nScore;
	
	public AudioSource SuccessClip;
	//public AudioSource FailureClip;
	
	//This routine starts the pickup for the object
	IEnumerator OnPickUp(){
		
		ik = BallIO.lastUsedInteractionSystem.GetComponent<FullBodyBipedIK> ();
		while (holdWeight < 1f) {
			
			holdWeight +=Time.deltaTime;
			yield return null;
		}
	}
	
	//This is to drop the ball from whereever you are
	IEnumerator Drop(){
		
		GetComponent<Rigidbody> ().isKinematic = false;
		GetComponent<Rigidbody> ().useGravity = true;
		transform.parent = null;
		while (holdWeight > 0f) {
			
			holdWeight +=Time.deltaTime*3f;
			yield return null;
		}
	}
	
	void LateUpdate(){
		
		if (ik == null)
			return;
		ik.solver.leftHandEffector.positionOffset += holdOffset * holdWeight;
		
		
	}
	// Use this for initialization
	void Start () {
		score = 0;
		//pScore = 1;
		//nScore = 1;
		countText.text = "Score: " + score.ToString();
		SuccessClip = GetComponent<AudioSource>();
		initballpos = right_hand_trans.ball.transform.position;
		handsmanage = InteractionManager.Instance;
	}

//	void OnCollisionEnter (Collision col)
//	{
//		if(col.gameObject.name == "hole")
//		{
//			Destroy(col.gameObject);
//		}
//	}


	// Update is called once per frame
	void Update () {
		
//		if (Vector3.Distance (target.transform.position, ballllll.transform.position) < 0.1f) {
//			//StartCoroutine (Drop ());
//			score++;
//			SuccessClip.Play ();
//			countText.text = "Score: " + score.ToString();
//			PlayerPrefs.SetString(PlayerPrefs.GetInt("GAMENUM").ToString() + "\t" + "handLocationData" + "\t" + score.ToString(), right_hand_trans.handLocationData);
//			Debug.Log(PlayerPrefs.GetInt("GAMENUM").ToString() + "\t" + right_hand_trans.handLocationData + "\t" + score.ToString());
//			//This following resets the position of the ball and makes everything to back to defualt.
//			
//			right_hand_trans.isTouchingBall = false;
//			right_hand_trans.ball.SetActive (false);
//			right_hand_trans.ball.transform.position = initballpos;
//			right_hand_trans.ball.SetActive (true);
//			right_hand_trans.ball.transform.parent = null;
//		} 



		if (Mathf.Abs (transform.position.x - target.transform.position.x) < .17f && Mathf.Abs (transform.position.y - target.transform.position.y) < .17f) {
			if(Mathf.Abs(transform.position.z - target.transform.position.z) < .17f){

				ballllll.transform.parent = null;
				ballllll.SetActive(false);
				ballllll.transform.position = initballpos;
				ballllll.SetActive(true);

				score++;
				countText.text = "Score: " + score.ToString();

			}
		}

		
		if (handsmanage.GetLastRightHandEvent() == InteractionManager.HandEventType.Release) {
			Debug.Log ("Let's Drop!");
			//StartCoroutine(Drop ());
			GetComponent<Rigidbody> ().isKinematic = false;
			GetComponent<Rigidbody> ().useGravity = true;
			transform.parent = null;
		}
		if (handsmanage.GetLastRightHandEvent() == InteractionManager.HandEventType.Grip) {
			//Debug.Log ("Let's Pickup!");

			//StartCoroutine(OnPickUp ());
		}
	}
	
}