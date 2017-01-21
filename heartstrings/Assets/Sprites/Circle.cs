using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public GameObject circle;
    public GameObject comet;
    public void spawn(float x, float y)
    {

        for (int i = 0; i < CSVReader.coordinatesAndText.Count - 1; i++)
        {

            circle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            circle.transform.position = new Vector2(float.Parse(CSVReader.coordinatesAndText[i][0]), float.Parse(CSVReader.coordinatesAndText[i][1]));
            circle.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            HeartstringCircle hsc = circle.AddComponent<HeartstringCircle>();
            hsc.comet = comet;

            circle.GetComponent<MeshRenderer>().enabled = false;
            //startPoints[i + 1] = new Vector2(timeScale * float.Parse(CSVReader.coordinatesAndText[i][0]), float.Parse(CSVReader.coordinatesAndText[i][1]));
        }

        //StartCoroutine(expand(circle));
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