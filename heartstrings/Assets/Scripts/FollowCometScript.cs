using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCometScript : MonoBehaviour {
	public GameObject comet;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3(comet.transform.position.x, transform.position.y, -10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(comet.transform.position.x, transform.position.y, -10);
	}
}
