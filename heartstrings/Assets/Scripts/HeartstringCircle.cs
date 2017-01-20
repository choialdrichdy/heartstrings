using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartstringCircle : MonoBehaviour {

    public GameObject comet;
	// Use this for initialization
	void Start () {
        Debug.Log("tesst");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        //check kung nsa circle na
        //destroy the circle
        float distance = computeDistance();
        if (distance < 1 && distance < 0.5)
        {
            Debug.Log("Great!");
        }
        else if (distance < 1 && distance > 0.5)
        {
            Debug.Log("Good!");
        }
        else if (distance > 1)
        {
            Debug.Log("Miss!");
        }
    }

    private float computeDistance()
    {
        float cometX = comet.transform.position.x;
        float cometY = comet.transform.position.y;

        float circleX = transform.position.x;
        float circleY = transform.position.y;

        float answer = Vector2.Distance(new Vector2(cometX, cometY), new Vector2(circleX, circleY));
        return answer;
    }
}
