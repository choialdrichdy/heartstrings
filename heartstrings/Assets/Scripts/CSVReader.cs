using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVReader : MonoBehaviour {

    private string[] coordinates;

    public static List<string[]> coordinatesAndText;

    private bool Load(string fileName)
    {
        // Handle any problems that might arise when reading the text
        try {
            string line;

            // StreamReader theReader = new StreamReader(fileName, Encoding.Default);
            StreamReader theReader = new StreamReader("Assets/Coordinates/temp.csv", Encoding.Default);

            using (theReader)
            {
                do
                {
                    line = theReader.ReadLine();
                    if (line != null)
                    {
                        coordinatesAndText.Add(line.Split(','));
                    }
                }
                while (line != null);
                theReader.Close();

                //for(int i = 0; i < textList.Count; i++)
                //{
                //    print(coordinatesList[i][0] + "," + coordinatesList[i][1] + " + " + textList[i]);
                //}

                return true;
            }
        }
        catch (IOException e)
        {
            return false;
        }
    }

    private bool Load()
    {

        coordinatesAndText.Add(new string[] { "2.000", "3", "Lights" });
        coordinatesAndText.Add(new string[] { "4.000", "0", "Over" });
        coordinatesAndText.Add(new string[] { "6.000", "3", "Kamogawa" });
        coordinatesAndText.Add(new string[] { "8.000", "0", "Lights" });
        coordinatesAndText.Add(new string[] { "10.000", "-1", "along" });
        coordinatesAndText.Add(new string[] { "12.000", "0", "the " });
        coordinatesAndText.Add(new string[] { "14.000", "-1", "shore" });
        coordinatesAndText.Add(new string[] { "16.000", "3", "Reflect" });
        coordinatesAndText.Add(new string[] { "18.000", "1", "on" });
        coordinatesAndText.Add(new string[] { "20.000", "2", "river's" });
        coordinatesAndText.Add(new string[] { "22.000", "-2", "surface" });
        coordinatesAndText.Add(new string[] { "24.000", "-1", "The" });
        coordinatesAndText.Add(new string[] { "26.000", "1", "stars" });
        coordinatesAndText.Add(new string[] { "28.000", "1", "drown" });
        coordinatesAndText.Add(new string[] { "30.000", "1", "in" });
        coordinatesAndText.Add(new string[] { "32.000", "3", "ink" });
        //coordinatesAndText.Add(new string[] { "33.000", "1", "temp" });
        //coordinatesAndText.Add(new string[] { "34.000", "-3", "temp" });

        //coordinatesAndText.Add(new string[] { "2.153","3","temp" });
        //coordinatesAndText.Add(new string[] { "4.131", "3", "temp" });
        //coordinatesAndText.Add(new string[] { "6.128", "3", "temp" });
        //coordinatesAndText.Add(new string[] { "8.028", "3", "temp" });

        return false;
    }

    private void Start()
    {
        coordinatesAndText = new List<string[]>();
        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
