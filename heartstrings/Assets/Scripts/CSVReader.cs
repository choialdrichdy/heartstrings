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

        //2.153,3,temp
        //4.131,3,temp
        //6.128,3,temp
        //8.028,3,temp
        coordinatesAndText.Add(new string[] { "2.153","3","temp" });
        coordinatesAndText.Add(new string[] { "4.131", "3", "temp" });
        coordinatesAndText.Add(new string[] { "6.128", "3", "temp" });
        coordinatesAndText.Add(new string[] { "8.028", "3", "temp" });

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
