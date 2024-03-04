using model3;
using model4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// <summary>
        /// 
        /// </summary>
        public string fips { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
    }

    public class Geometry
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<List<List<double>>> coordinates { get; set; }
    }

    public class FeaturesItem
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Properties properties { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Geometry geometry { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FeaturesItem> features { get; set; }
    }

}



public class Test2 : MonoBehaviour
{
    void Start()
    {

        foreach (var item in new DirectoryInfo(Application.streamingAssetsPath).GetFiles())
        {
            if (item.Extension == ".json")
            {
                Guid guid=new Guid();
                try
                {
                    model4.Root root = JsonConvert.DeserializeObject<model4.Root>(File.ReadAllText(item.FullName));
                    foreach (Feature feature in root.features)
                    {
                        foreach (List<List<List<double>>> item1 in feature.geometry.coordinates)
                        {

                            foreach (List<List<double>> item2 in item1)
                            {
                                List<Vector2> vector2s = new List<Vector2>();
                                foreach (List<double> item3 in item2)
                                {
                                    vector2s.Add(new Vector2((float)item3[0], (float)item3[1]));
                                }
                                guid= MapDrawer.DrawMap(vector2s, UnityEngine.Random.Range(1, 3), Color.black, Color.blue, false, .2f);
                                MapDrawer.SetBlockColor(guid, Color.green);
                                //MapDrawer.Delete(guid);
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

                            foreach (List<double> item2 in item1)
                            {
                                vector2s.Add(new Vector2((float)item2[0], (float)item2[1]));
                            }
                            guid = MapDrawer.DrawMap(vector2s, UnityEngine.Random.Range(1, 3), Color.black, Color.blue, true, .2f);
                            return;

                        }
                    }
                }
                
            }
        }
    }
}
