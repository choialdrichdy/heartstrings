using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    private float x;
    private float y;

    // Use this for initialization
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;
        transform.position = new Vector2(x + 0.4f, y);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.RotateAround(new Vector3(x, y, 0.0f), new Vector3(0.0f, 0.0f, 0.1f), Time.time);
    }
}
