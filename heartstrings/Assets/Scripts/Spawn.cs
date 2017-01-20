using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Circle circle;
    //Time it takes to spawn theGoodies
    [Space(3)]
    public float waitingForNextSpawn = 1;
    public float theCountdown = 1;

    // the range of X
    [Header("X Spawn Range")]
    public float xMin = 0.0f;
    public float xMax = 10.0f;

    // the range of y
    [Header("Y Spawn Range")]
    public float yMin = 0.0f;
    public float yMax = 10.0f;

    void Start()
    {
        Circle circle = gameObject.AddComponent<Circle>() as Circle;
        circle.spawn(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    }

    // Update is called once per frame
    void Update()
    {
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnBeats();
            theCountdown = waitingForNextSpawn;
        }
    }

    void SpawnBeats()
    {
        Circle circle = gameObject.AddComponent<Circle>() as Circle;
        circle.spawn(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    }
}