using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    
    private string[] texts = { "HELLO", "WORLD", "CORN", "FLUFFY", "SLEEPY", "GABRIEL", "IGLESIAS"};

    // Use this for initialization
    private void initControlPoints()
    {
        float middleX = (endPoints[index].x + startPoints[index].x) / 2;

        int controlOffset = 3;

        if (isInverted) {
            controlOffset *= -1;
        }

        control1 = new Vector2((startPoints[index].x + middleX) / 2, startPoints[index].y + controlOffset);
        control2 = new Vector2((endPoints[index].x + middleX) / 2, endPoints[index].y - controlOffset);
    }

    void Start()
    {
        for (int i = 0; i < CSVReader.coordinatesAndText.Count; i++)
        {
            circle = (GameObject)Instantiate(Resources.Load("RotatingCircleWText"));
            circle.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            circle.transform.position = new Vector2(float.Parse(CSVReader.coordinatesAndText[i][0]) * 2, float.Parse(CSVReader.coordinatesAndText[i][1]));
            HeartstringCircle hsc = circle.AddComponent<HeartstringCircle>();
            Canvas[] canvas = circle.GetComponentsInChildren<Canvas>();
            Text text = canvas[0].GetComponentInChildren<Text>();
            text.text = texts[i];
        }

        audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
            audioSource.Stop();

        timeScale = 2;
        index = 0;

        if (startMoveTime != -1)
            timeOffset = startMoveTime;
        else
            timeOffset = 0;

        //        2.153,3,temp
        //4.131,3,temp
        //6.128,3,temp
        //8.028,3,temp

        startPoints = new Vector2[CSVReader.coordinatesAndText.Count];
        startTimes = new float[CSVReader.coordinatesAndText.Count];
        startPoints[0] = new Vector2(0, 3);
        startTimes[0] = 0 + timeOffset;

        for (int i = 0; i < CSVReader.coordinatesAndText.Count - 1; i++)
        {
            startPoints[i + 1] = new Vector2(timeScale * float.Parse(CSVReader.coordinatesAndText[i][0]), float.Parse(CSVReader.coordinatesAndText[i][1]));
            startTimes[i + 1] = float.Parse(CSVReader.coordinatesAndText[i][0]) + timeOffset;
        }

        endPoints = new Vector2[CSVReader.coordinatesAndText.Count];
        endTimes = new float[CSVReader.coordinatesAndText.Count];
        endPoints[0] = new Vector2(startPoints[1][0], startPoints[1][1]);
        endTimes[0] = startPoints[1][0];
        for (int i = 1; i < CSVReader.coordinatesAndText.Count; i++)
        {
            endPoints[i] = new Vector2(timeScale * float.Parse(CSVReader.coordinatesAndText[i][0]), float.Parse(CSVReader.coordinatesAndText[i][1]));
            endTimes[i] = float.Parse(CSVReader.coordinatesAndText[i][0]) + timeOffset;
        }

        transform.position = startPoints[index];
        initControlPoints();
    }

    // Update is called once per frame
    void Update()
    {
        if (index < CSVReader.coordinatesAndText.Count + 1 && Time.time >= endTimes[index])
        {
            index++;
            if (index == CSVReader.coordinatesAndText.Count)
            {
                if (audioSource != null)
                    audioSource.enabled = false;
                index = CSVReader.coordinatesAndText.Count - 1;
            }
            initControlPoints();
        }

        if (Time.time >= startTimes[index])
        {
            if (audioSource != null && !audioSource.isPlaying && audioSource.enabled)
            {
                audioSource.Play();
            }
            transform.position = bezier(Time.time);
        }

    }

    Vector2 bezier(float time)
    {
        float t = (time - startTimes[index]) / (endTimes[index] - startTimes[index]);
        Vector2 x = (Mathf.Pow(1 - t, 3) * startPoints[index]) +
            (3 * Mathf.Pow(1 - t, 2) * t * control1) +
            (3 * (1 - t) * Mathf.Pow(t, 2) * control2) +
            Mathf.Pow(t, 3) * endPoints[index];

        t = 1;
        Vector2 y = (Mathf.Pow(1 - t, 3) * startPoints[index]) +
            (3 * Mathf.Pow(1 - t, 2) * t * control1) +
            (3 * (1 - t) * Mathf.Pow(t, 2) * control2) +
            Mathf.Pow(t, 3) * endPoints[index];
        print("endpoint at " + y);
        return x;
    }
}
