using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartstringCircle : MonoBehaviour {

    private bool canclick;

    public GameObject comet;
    public Text text;
    public GameObject target;
    public GameObject AnimatorPrefab;

    // Use this for initialization
    void Start () {

        canclick = true;
        //GameObject[] objects = GameObject.FindGameObjectsWithTag("Comet");
        Debug.Log(AnimatorPrefab + "<-- not null");
        comet = GameObject.FindGameObjectWithTag("Comet");
        if (comet == null)
        {
            print("hello");
        }

    }
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                pressScreen();

            }
        }
    }

    private void OnMouseDown()
    {
        pressScreen();
    }

    private void pressScreen()
    {

        //if (!canclick)
        //    return;

        //canclick = !canclick;

        float distance = computeDistance();
        int score = PlayerPrefs.GetInt("score", 0);
        if (distance < 1 && distance < 0.5)
        {
            PlayerPrefs.SetInt("score", (score ++));
            StartCoroutine(PlayAnimation());
            StopCoroutine(PlayAnimation());
            //AnimatorPrefab = (GameObject) Instantiate(Resources.Load("TapAnimation"), transform.position, transform.rotation);
            Debug.Log("Great!");
            //text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
            //text.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";

        }
        else if (distance < 1 && distance > 0.5)
        {
            PlayerPrefs.SetInt("score", score++);
            Debug.Log("Good!");
            StartCoroutine(PlayAnimation());
            StopCoroutine(PlayAnimation());
            //text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
            //text.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        }
        else if (distance > 1)
        {
            PlayerPrefs.SetInt("score", (score - 0));
            Debug.Log("Miss!");
        }
    }

    IEnumerator PlayAnimation ()
    {
        AnimatorPrefab = (GameObject)Instantiate(Resources.Load("TapAnimation"), transform.position, transform.rotation);
        yield return new WaitForSeconds(0.4f);
        Destroy(AnimatorPrefab);
        if (AnimatorPrefab != null)
            AnimatorPrefab = null;

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
