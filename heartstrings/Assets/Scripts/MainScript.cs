using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Round
{
    public string round;
    public int round_time;
    public int total_points;
    public int minimum_points;
    public string music_file;
    public string music_coordinates;
}

public class MainScript : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Start()
    {
        string url = "file://Assets/Others/round_info.json";
        WWW www = new WWW(url);
        yield return www;
        if (www.error == null)
        {
            Processjson(www.text);
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
    }

    private void Processjson(string jsonString)
    {
        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        Round parsejson;
        Debug.Log(jsonvale.Count);
        /*for (int i = 0; i < jsonvale.Count; i++)
        {

        }
        parsejson = new Round();
        parsejson.round = jsonvale["round"].ToString();
        parsejson.round_time = int.Parse(jsonvale["round_time"].ToString());
        parsejson.total_points = int.Parse(jsonvale["total_points"].ToString());
        parsejson.minimum_points = int.Parse(jsonvale["minimum_points"].ToString());
        parsejson.music_file = jsonvale["music_file"].ToString();
        parsejson.music_coordinates = jsonvale["music_coordinates"].ToString();*/
    }
}
