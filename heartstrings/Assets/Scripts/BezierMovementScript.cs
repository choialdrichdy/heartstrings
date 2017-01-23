using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BezierMovementScript : MonoBehaviour
{
    public Vector2[] startPoints;
    public Vector2[] endPoints;
    public float[] startTimes;
    public float[] endTimes;

    private Vector2 control1;
    private Vector2 control2;

    private int index;

    public bool isInverted;
    public float startMoveTime;

    private float timeOffset;
    private float timeScale;

    private AudioSource audioSource;

    private GameObject circle;
    public GameObject comet;

    private float timeStarted = 0;
    private bool test = false;

    public List<string[]> coordinatesAndText;


    // Use this for initialization
    private void initControlPoints()
    {
        float middleX = (endPoints[index].x + startPoints[index].x) / 2;

        int controlOffset = 3;

        if (isInverted)
        {
            controlOffset *= -1;
        }

        control1 = new Vector2((startPoints[index].x + middleX) / 2, startPoints[index].y + controlOffset);
        control2 = new Vector2((endPoints[index].x + middleX) / 2, endPoints[index].y - controlOffset);
    }

    void Start()
    {
        
        if (SceneManager.GetActiveScene().name.Equals("MainGame")) {
            coordinatesAndText = CSVReader.coordinatesAndText;
            timeScale = 3.5f;
        }
        else if (SceneManager.GetActiveScene().name.Equals("SecondGame")) {
            coordinatesAndText = CSVReader.coordinatesAndText2;
            timeScale = 3.5f*(140.0f/120);
        }
        else {
            coordinatesAndText = CSVReader.coordinatesAndText3;
            timeScale = 6.5f;
        }

        index = 0;

        for (int i = 0; i < coordinatesAndText.Count; i++)
        {
            circle = (GameObject)Instantiate(Resources.Load("RotatingCircleWText"));
            circle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            circle.transform.position = new Vector2(float.Parse(coordinatesAndText[i][0]) * timeScale, float.Parse(coordinatesAndText[i][1]));

            Text text = circle.GetComponentInChildren<Text>();
            text.text = coordinatesAndText[i][2];

            HeartstringCircle hsc = circle.GetComponentInChildren<HeartstringCircle>();
            hsc.text = text;
        }

        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
            audioSource.Stop();

        

        timeOffset = startMoveTime;

        startPoints = new Vector2[coordinatesAndText.Count];
        startTimes = new float[coordinatesAndText.Count];
        startPoints[0] = new Vector2(0, 3);
        startTimes[0] = 0 + timeOffset;

        for (int i = 0; i < coordinatesAndText.Count - 1; i++)
        {
            startPoints[i + 1] = new Vector2(timeScale * float.Parse(coordinatesAndText[i][0]), float.Parse(coordinatesAndText[i][1]));
            startTimes[i + 1] = float.Parse(coordinatesAndText[i][0]) + timeOffset;
        }

        endPoints = new Vector2[coordinatesAndText.Count];
        endTimes = new float[ coordinatesAndText.Count];
        endPoints[0] = new Vector2(startPoints[1][0], startPoints[1][1]);
        endTimes[0] = startTimes[1];
        for (int i = 1; i < coordinatesAndText.Count; i++)
        {
            endPoints[i] = new Vector2(timeScale * float.Parse(coordinatesAndText[i][0]), float.Parse(coordinatesAndText[i][1]));
            print(this.gameObject.name + " end points " + endPoints[i]);
            endTimes[i] = float.Parse(coordinatesAndText[i][0]) + timeOffset;
            print(this.gameObject.name + " end times " + endTimes[i]);
        }

        initControlPoints();
        transform.position = startPoints[index];
        timeStarted = Time.timeSinceLevelLoad;
        test = true;
    }

    // Update is called once per frame
    void Update()
    {
        float normalizedTime = Time.timeSinceLevelLoad;

        if (index < coordinatesAndText.Count + 1 && normalizedTime >= endTimes[index])
        {
            index++;
            if (index == coordinatesAndText.Count)
            {
                if (audioSource != null)
                    audioSource.enabled = false;
                index = coordinatesAndText.Count - 1;
                transform.position = endPoints[index];
                return;
            }
            initControlPoints();
        }

        if (normalizedTime >= startTimes[index])
        {
            if (audioSource != null && !audioSource.isPlaying && audioSource.enabled)
            {
                audioSource.Play();
            }
            transform.position = bezier(normalizedTime);
        }
    }

    Vector2 bezier(float time)
    {
        float t = (time - startTimes[index]) / (endTimes[index] - startTimes[index]);
        Vector2 x = (Mathf.Pow(1 - t, 3) * startPoints[index]) +
            (3 * Mathf.Pow(1 - t, 2) * t * control1) +
            (3 * (1 - t) * Mathf.Pow(t, 2) * control2) +
            Mathf.Pow(t, 3) * endPoints[index];

        return x;
    }
}
