using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneCameraMover : MonoBehaviour {
    //time counter basically makes sure this runs for 10 seconds
    public float time1;
    public float time2;
    public float moveX;
	void Start () {
	}

	void Update () {
        /**if (index >= interestPoints.Length)
            index = interestPoints.Length - 1;**/
        if (Time.timeSinceLevelLoad > time1 && Time.timeSinceLevelLoad < time2)
        {
            transform.Translate(new Vector3(moveX, 0.0f, 0.0f));
        }

	}
}
