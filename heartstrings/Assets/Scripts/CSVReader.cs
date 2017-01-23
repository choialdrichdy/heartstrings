using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CSVReader : MonoBehaviour {

    private string[] coordinates;

    public static List<string[]> coordinatesAndText;
    public static List<string[]> coordinatesAndText2;
    public static List<string[]> coordinatesAndText3;

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

        coordinatesAndText2.Add(new string[] { "0.840", "1", "Sea" });
        coordinatesAndText2.Add(new string[] { "1.680", "0", "of" });
        coordinatesAndText2.Add(new string[] { "2.520", "-1", "Stars" });
        coordinatesAndText2.Add(new string[] { "3.360", "2", "A" });
        coordinatesAndText2.Add(new string[] { "4.200", "2", "lonely" });
        coordinatesAndText2.Add(new string[] { "5.040", "0", "vessel," });
        coordinatesAndText2.Add(new string[] { "5.880", "1", "a" });
        coordinatesAndText2.Add(new string[] { "6.720", "2", "sea" });
        coordinatesAndText2.Add(new string[] { "7.560", "1", "of" });
        coordinatesAndText2.Add(new string[] { "8.400", "0", "constellations--" });
        coordinatesAndText2.Add(new string[] { "9.240", "3", "The"});
        coordinatesAndText2.Add(new string[] { "10.080", "1", "pilgrim," });
        coordinatesAndText2.Add(new string[] { "11.760", "1", "becalmed,,," });
        coordinatesAndText2.Add(new string[] { "14.280", "1", "rests" });
        coordinatesAndText2.Add(new string[] { "15.120", "0", "his" });
        coordinatesAndText2.Add(new string[] { "15.960", "-1", "arms," });
        coordinatesAndText2.Add(new string[] { "16.800", "2", "lays" });
        coordinatesAndText2.Add(new string[] { "17.640", "2", "up" });
        coordinatesAndText2.Add(new string[] { "18.480", "0", "his" });
        coordinatesAndText2.Add(new string[] { "19.320", "1", "oar.,." });
        coordinatesAndText2.Add(new string[] { "20.160", "2", "Though" });
        coordinatesAndText2.Add(new string[] { "21.000", "1", "he" });
        coordinatesAndText2.Add(new string[] { "21.840", "0", "sleeps," });
        coordinatesAndText2.Add(new string[] { "22.680", "3", "night." });
        coordinatesAndText2.Add(new string[] { "23.520", "1", "still" });
        coordinatesAndText2.Add(new string[] { "25.200", "1", "passes." });

        coordinatesAndText3.Add(new string[] { "0.666", "-1", "Light" });
        coordinatesAndText3.Add(new string[] { "2.000", "2", "slips" });
        coordinatesAndText3.Add(new string[] { "2.666", "-2", "as" });
        coordinatesAndText3.Add(new string[] { "3.333", "-1", "rain" });
        coordinatesAndText3.Add(new string[] { "4.666", "-2", "falls" });
        coordinatesAndText3.Add(new string[] { "5.999", "-1", "in" });
        coordinatesAndText3.Add(new string[] { "7.333", "2", "the" });
        coordinatesAndText3.Add(new string[] { "7.999", "-2", "city." });
        coordinatesAndText3.Add(new string[] { "8.666", "-1", "Rain" });
        coordinatesAndText3.Add(new string[] { "9.999", "-2", "floods" });
        coordinatesAndText3.Add(new string[] { "11.332", "-1", "passages" });
        coordinatesAndText3.Add(new string[] { "12.666", "2", "of" });
        coordinatesAndText3.Add(new string[] { "13.332", "-2", "anthills" });
        coordinatesAndText3.Add(new string[] { "13.999", "-1", "and" });
        coordinatesAndText3.Add(new string[] { "15.332", "-2", "city" });
        coordinatesAndText3.Add(new string[] { "16.665", "-1", "streets." });
        coordinatesAndText3.Add(new string[] { "17.999", "2", "Ants" });
        coordinatesAndText3.Add(new string[] { "18.665", "-2", "shelter" });
        coordinatesAndText3.Add(new string[] { "19.332", "-1", "under" });
        coordinatesAndText3.Add(new string[] { "20.665", "-2", "The" });
        coordinatesAndText3.Add(new string[] { "21.998", "-1", "wings" });
        coordinatesAndText3.Add(new string[] { "23.332", "2", "of" });
        coordinatesAndText3.Add(new string[] { "23.998", "-2", "a" });
        coordinatesAndText3.Add(new string[] { "24.665", "-1", "fallen" });
        coordinatesAndText3.Add(new string[] { "25.998", "-2", "moth." });
        coordinatesAndText3.Add(new string[] { "27.331", "-1", "Who" });
        coordinatesAndText3.Add(new string[] { "28.665", "2", "would" });
        coordinatesAndText3.Add(new string[] { "29.331", "-2", "share" });
        coordinatesAndText3.Add(new string[] { "29.998", "-1", "an" });
        coordinatesAndText3.Add(new string[] { "31.331", "-2", "umbrella?" });

        return false;
    }

    private void Start()
    {
        coordinatesAndText = new List<string[]>();
        coordinatesAndText2 = new List<string[]>();
        coordinatesAndText3 = new List<string[]>();
        Load();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
