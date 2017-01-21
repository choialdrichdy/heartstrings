using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    public int total;
    public int got;

	// Use this for initialization
	void Start () {
        got = 0;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void successfulClick()
    {
        got++;
    }
}
