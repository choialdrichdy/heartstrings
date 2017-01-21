using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

public class RoundManager : MonoBehaviour {

    public static List<Round> roundlist;
	// Update is called once per frame
	void Update () {
		
	}

    void Start()
    {
        string line;
        line = File.ReadAllText("Assets/Others/round_info.json");
        roundlist = RoundManager.Processjson(line);
        Round startingRound = decideRound(null, 0);
        loadRound(startingRound);
    }

    public static List<Round> Processjson(string jsonString)
    {
        JsonData jsonvale = JsonMapper.ToObject(jsonString);
        List<Round> roundlist = new List<Round>();
        for (int i = 0; i < jsonvale.Count; i++)
        {
            Round oneround = new Round();
            oneround.round = jsonvale[i]["round"].ToString();
            oneround.round_time = int.Parse(jsonvale[i]["round_time"].ToString());
            oneround.total_points = int.Parse(jsonvale[i]["total_points"].ToString());
            oneround.minimum_points = int.Parse(jsonvale[i]["minimum_points"].ToString());
            oneround.music_file = jsonvale[i]["music_file"].ToString();
            oneround.music_coordinates = jsonvale[i]["music_coordinates"].ToString();
            roundlist.Add(oneround);
        }

        return roundlist;
    }

    public static Round decideRound(Round currentRound, int total)
    {
        if (currentRound == null && total == 0)
        {
            return roundlist[0];
        }
        if (total >= currentRound.minimum_points)
        {

        }
        return null;
    }

    public static void loadRound(Round round)
    {
        //Load shit here
    }
}
