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

        text = GameObject.FindWithTag("Text").GetComponent<Text>() as Text;
        if (text == null)
        {
            print("a;dslkfj");
        }
        else
        {
            print("helowoefwaj;oefijslkdfjlsdkfj");
        }

        //if(objects.Length > 0)
        //    comet = objects[0];
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

        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
        //    RaycastHit hit;
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    if (Physics.Raycast(ray, out hit))
        //        if (hit.collider !=null)
        //            Instantiate(target, hit.point, transform.rotation);
        //}

    }

    private void OnMouseDown()
    {
        pressScreen();
    }

    private void pressScreen()
    {

        if (!canclick)
            return;

        canclick = !canclick;

        float distance = computeDistance();
        int score = PlayerPrefs.GetInt("score", 0);
        if (distance < 1 && distance < 0.5)
        {
            PlayerPrefs.SetInt("score", (score ++));
            StartCoroutine("PlayAnimation");
            //AnimatorPrefab = (GameObject) Instantiate(Resources.Load("TapAnimation"), transform.position, transform.rotation);
            Debug.Log("Great!");
            //text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
            //text.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        }
        else if (distance < 1 && distance > 0.5)
        {
            PlayerPrefs.SetInt("score", score++);
            Debug.Log("Good!");
            StartCoroutine("PlayAnimation");

            //text.color = new Color(text.color.r, text.color.g, text.color.b, 1.0f);
            //text.text = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        }
        else if (distance > 1)
        {
            PlayerPrefs.SetInt("score", (score - 0));
            Debug.Log("Miss!");
            text.color = new Color(text.color.r, text.color.g, text.color.b, 0f);
            text.text = "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF";
        }
    }

    IEnumerator PlayAnimation ()
    {
        AnimatorPrefab = (GameObject)Instantiate(Resources.Load("TapAnimation"), transform.position, transform.rotation);
        yield return new WaitForSeconds(0.4f);
        Destroy(AnimatorPrefab);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Circle")
        {
            print(";ldsakjf;lakdjs;flkadf");
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
