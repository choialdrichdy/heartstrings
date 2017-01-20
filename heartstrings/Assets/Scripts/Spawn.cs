using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Circle circle;
    public GameObject comet;
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
        circle.comet = comet;
        circle.spawn(9, 0);
        circle.spawn(27, 0);

        /*startPoints = new Vector2[2]{
            new Vector2(-9,0),
            new Vector2(9,0)
        };

        endPoints = new Vector2[2]{
            new Vector2(9,0),
            new Vector2(27,0)
        };*/
    }

    // Update is called once per frame
    //void Update()
    //{
    //    theCountdown -= Time.deltaTime;
    //    if (theCountdown <= 0)
    //    {
    //        SpawnBeats();
    //        theCountdown = waitingForNextSpawn;
    //    }
    //}

    void SpawnBeats(float x, float y)
    {
        Circle circle = gameObject.AddComponent<Circle>() as Circle;
        circle.spawn(x, y);
    }
}