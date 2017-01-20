using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        index = 0;

        if (startMoveTime != -1)
            timeOffset = startMoveTime;
        else
            timeOffset = 0;

        startPoints = new Vector2[2]{
            new Vector2(-9,0),
            new Vector2(9,0)
        };

        endPoints = new Vector2[2]{
            new Vector2(9,0),
            new Vector2(27,0)
        };

        startTimes = new float[2]{
            0+timeOffset,
            5+timeOffset
        };

        endTimes = new float[2]{
            5+timeOffset,
            10+timeOffset
        };

        transform.position = startPoints[index];
        initControlPoints();
    }

    // Update is called once per frame
    void Update()
    {
        if (index < 2 && Time.time >= endTimes[index])
        {
            index++;
            if (index == 2)
                index = 1;
            initControlPoints();
        }

        if (Time.time >= startTimes[index])
            transform.position = bezier(Time.time);
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
