using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartstringCircle : MonoBehaviour {

    public GameObject comet;
    GameObject particle;
    // Use this for initialization
    void Start () {
        //GameObject[] objects = GameObject.FindGameObjectsWithTag("Comet");
        comet = GameObject.FindGameObjectWithTag("Comet");
        if (comet == null)
        {
            print("hello");
        }
        //if(objects.Length > 0)
        //    comet = objects[0];
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray)) {
                    pressScreen();
                    Instantiate(particle, transform.position, transform.rotation);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        pressScreen();
    }

    private void pressScreen()
    {
        float distance = computeDistance();
        int score = PlayerPrefs.GetInt("score", 0);
        if (distance < 1 && distance < 0.5)
        {
            PlayerPrefs.SetInt("score", (score + 2));
            Debug.Log("Great!");
            

        }
        else if (distance < 1 && distance > 0.5)
        {
            PlayerPrefs.SetInt("score", score++);
            Debug.Log("Good!");
        }
        else if (distance > 1)
        {
            PlayerPrefs.SetInt("score", (score - 1));
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
