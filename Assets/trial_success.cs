using UnityEngine;
using System.Collections;

public class trial_success : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter (Collision col)
	{
		if (col.gameObject.name == "ball") {
			Destroy(col.gameObject);
		}
	}

}
