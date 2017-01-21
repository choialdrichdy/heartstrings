using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartstringCircle : MonoBehaviour {

    public GameObject comet;
	// Use this for initialization
	void Start () {
        //GameObject[] objects = GameObject.FindGameObjectsWithTag("Comet");
        comet = GameObject.FindGameObjectWithTag("Comet");
        //if(objects.Length > 0)
        //    comet = objects[0];
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        print("on moutles tdonw");

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

        print(cometX + ", " + cometY);

        float circleX = transform.position.x;
        float circleY = transform.position.y;

        float answer = Vector2.Distance(new Vector2(cometX, cometY), new Vector2(circleX, circleY));
        return answer;
    }
}
