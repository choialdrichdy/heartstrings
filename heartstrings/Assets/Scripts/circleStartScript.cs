using UnityEngine;
using System.Collections;

public class circleStartScript : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 0, 1), 3.0f);
	}
}
