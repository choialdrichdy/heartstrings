using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneCameraMover : MonoBehaviour {
	//time counter basically makes sure this runs for 10 seconds
	private float TIME_COUNTER = 10f; 
	public float speedOfXMovement = 0.025f;

	void Start () {
	}

	void Update () {
		if (Time.time < TIME_COUNTER) {
			transform.Translate (new Vector3(speedOfXMovement,0.00f)); // Decrease the x value to make it slower
		}
	}
}
