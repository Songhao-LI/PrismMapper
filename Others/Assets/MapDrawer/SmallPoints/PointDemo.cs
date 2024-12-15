using model3;
using model4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TriangleNet;
using UnityEngine;
public class PointDemo : MonoBehaviour
{
    void Start()
    {

        List<Guid> guids = new List<Guid>();
        List<List<Vector2>> postions = new List<List<Vector2>>();
        foreach (var item in new DirectoryInfo(Application.streamingAssetsPath).GetFiles())
        {
            if (item.Extension == ".json")
            {

                //try
                //{
                //    model4.Root root = JsonConvert.DeserializeObject<model4.Root>(File.ReadAllText(item.FullName));
                //    foreach (Feature feature in root.features)
                //    {
                //        foreach (List<List<List<double>>> item1 in feature.geometry.coordinates)
                //        {

                //            foreach (List<List<double>> item2 in item1)
                //            {
                //                List<Vector2> vector2s = new List<Vector2>();
                //                foreach (List<double> item3 in item2)
                //                {
                //                    vector2s.Add(new Vector2((float)item3[0], (float)item3[1]));
                //                }
                //                guid= MapDrawer.DrawMap(vector2s, UnityEngine.Random.Range(1, 3), Color.black, Color.blue, false, .2f);
                //                MapDrawer.SetBlockColor(guid, Color.green);
                //                //MapDrawer.Delete(guid);
                //            }

                //        }
                //    }
                //}
                //catch
                //{
                //    model3.Root root = JsonConvert.DeserializeObject<model3.Root>(File.ReadAllText(item.FullName));
                //    foreach (FeaturesItem feature in root.features)
                //    {
                //        foreach (List<List<double>> item1 in feature.geometry.coordinates)
                //        {
                //            List<Vector2> vector2s = new List<Vector2>();

                //            foreach (List<double> item2 in item1)
                //            {
                //                vector2s.Add(new Vector2((float)item2[0], (float)item2[1]));
                //            }
                //            guid = MapDrawer.DrawMap(vector2s, UnityEngine.Random.Range(1, 3), Color.black, Color.blue, true, .2f);
                //            return;
                //        }
                //    }
                //}

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
                                    double[] newPos = MapDrawer.TransformCoordinates(item3.ToArray());
                                    vector2s.Add(new Vector2((float)newPos[0] / 10000, (float)newPos[1] / 10000));
                                }
                                postions.Add(vector2s);
                            }
                        }
                    }

                }
                catch
                {
                    model3.Root root = JsonConvert.DeserializeObject<model3.Root>(File.ReadAllText(item.FullName));
                    foreach (FeaturesItem feature in root.features)
                    {
                        //List<List<Vector2>> postions = new List<List<Vector2>>();
                        foreach (List<List<double>> item1 in feature.geometry.coordinates)
                        {
                            List<Vector2> vector2s = new List<Vector2>();

                            foreach (List<double> item2 in item1)
                            {
                                //vector2s.Add(new Vector2((float)item2[0], (float)item2[1]));
                                double[] newPos = MapDrawer.TransformCoordinates(item2.ToArray());
                                vector2s.Add(new Vector2((float)newPos[0] / 10000, (float)newPos[1] / 10000));
                            }
                            postions.Add(vector2s);
                        }
                        //MapDrawer.CreateBaseMap(postions, .1f, Color.black, Color.blue, false, .2f);
                    }
                }


            }

        }
        guids = MapDrawer.CreateBaseMap(postions, .1f, Color.black, Color.blue, false, .2f);
        MapDrawer.AddPrismMap(guids[0], 3);
        //MapDrawer.AddDotDensityMap(guids[1], Color.blue, 1);
        //MapDrawer.AddDotDensityMap(guids[2], Color.red, 2);
        //MapDrawer.AddDotDensityMap(guids[3], Color.yellow, 2);
    }
}
