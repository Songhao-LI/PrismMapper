using model3;
using model4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using TriangleNet;
using UnityEngine;
namespace model4
{
    public class Feature
    {
        public string type { get; set; }
        public string id { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<List<double>>>> coordinates { get; set; }
    }

    public class Properties
    {
        public string fips { get; set; }
        public string name { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public List<Feature> features { get; set; }
    }

}
namespace model3
{
    public class Properties
    {
        public string fips { get; set; }
        public string name { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class FeaturesItem
    {
        public string type { get; set; }
        public string id { get; set; }
        public Properties properties { get; set; }
        public Geometry geometry { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public List<FeaturesItem> features { get; set; }
    }

}



public class Test : MonoBehaviour
{
    private Color[] gradientColors;

    void Start()
    {
        float r = 160f / 255;
        float g = 145f / 255;
        float b = 170f / 255;
        Color testColor = new Color(r, g, b, 1f);


        gradientColors = new Color[100];
        for (int i = 0; i < gradientColors.Length; i++)
        {
            float t = i / (gradientColors.Length - 1.0f);
            gradientColors[i] = Color.Lerp(Color.yellow, Color.red, t);
        }

        foreach (var item in new DirectoryInfo(Application.streamingAssetsPath).GetFiles())
        {

            if (item.Extension == ".json")
            {
                try
                {
                    model4.Root root = JsonConvert.DeserializeObject<model4.Root>(File.ReadAllText(item.FullName));
                    foreach (Feature feature in root.features)
                    {
                        foreach (List<List<List<double>>> item1 in feature.geometry.coordinates)
                        {
                            foreach (List<List<double>> item2 in item1)
                            {
                                // Color randomColor = gradientColors[UnityEngine.Random.Range(0, gradientColors.Length)];
                                List<Vector2> vector2s = new List<Vector2>();
                                foreach (List<double> item3 in item2)
                                {
                                    vector2s.Add(new Vector2((float)item3[0], (float)item3[1]));
                                }
                                MapDrawer.DrawMap(vector2s,UnityEngine.Random.Range(1,5), testColor, Color.black, true,.2f);
                            }
                        }
                    }
                }
                catch
                {
                    model3.Root root = JsonConvert.DeserializeObject<model3.Root>(File.ReadAllText(item.FullName));
                    foreach (FeaturesItem feature in root.features)
                    {
                        foreach (List<List<double>> item1 in feature.geometry.coordinates)
                        {
                            List<Vector2> vector2s = new List<Vector2>();
                            // Color randomColor = gradientColors[UnityEngine.Random.Range(0, gradientColors.Length)];
                            foreach (List<double> item2 in item1)
                            {

                                vector2s.Add(new Vector2((float)item2[0], (float)item2[1]));
                            }
                            MapDrawer.DrawMap(vector2s, UnityEngine.Random.Range(1, 5), testColor, Color.black, true,.2f);

                        }
                    }
                }

            }
        }
    }
}
