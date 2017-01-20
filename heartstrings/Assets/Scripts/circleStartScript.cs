using UnityEngine;
using System.Collections;

public class circleStartScript : MonoBehaviour {

	float angle =0;
	float speed = (2 * Mathf.PI) / 5;
	float radius= 0.032f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		angle += speed*Time.deltaTime; //if you want to switch direction, use -= instead of +=
		transform.Translate (Mathf.Cos(angle)*radius, Mathf.Sin(angle)*radius, 0);
	}
}
