using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject circle;
    public void spawn(float x, float y)
    {
        circle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        circle.transform.position = new Vector2(x, y);
        circle.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        StartCoroutine(expand(circle));
    }
    public IEnumerator expand(GameObject circle)
    {
        for (float i = 0.2f; i <= 1.5f; i += 0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            circle.transform.localScale = new Vector3(i, i, i);
        }
    }
}