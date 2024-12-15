using model3;
using model4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TriangleNet;
using UnityEngine;
using Newtonsoft.Json.Linq;
using System.Collections;
namespace CustomJ
{
    public class Properties
    {
        /// <summary>
        /// 
        /// </summary>
        public string featurecla { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int scalerank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int labelrank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sovereignt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string sov_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int adm0_dif { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tlc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string admin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int geou_dif { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string geounit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string gu_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int su_dif { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subunit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string su_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int brk_diff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_long { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string brk_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string brk_name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string brk_group { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string abbrev { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string postal { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string formal_en { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string formal_fr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_ciawf { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string note_adm0 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string note_brk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_sort { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_alt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mapcolor7 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mapcolor8 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mapcolor9 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int mapcolor13 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pop_est { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pop_rank { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int pop_year { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int gdp_md { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int gdp_year { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string economy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string income_grp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fips_10 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iso_a2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iso_a2_eh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iso_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iso_a3_eh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iso_n3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string iso_n3_eh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string un_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wb_a2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wb_a3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int woe_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int woe_id_eh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string woe_note { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_iso { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_diff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_tlc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_us { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_fr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_ru { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_es { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_cn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_tw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_np { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_pk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_de { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_gb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_br { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_il { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_ps { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_sa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_eg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_ma { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_pt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_ar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_jp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_ko { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_vn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_tr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_pl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_gr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_it { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_nl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_se { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_bd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string adm0_a3_ua { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int adm0_a3_un { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int adm0_a3_wb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string continent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region_un { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string subregion { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string region_wb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int name_len { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int long_len { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int abbrev_len { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int tiny { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int homepart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int min_zoom { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double min_label { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int max_label { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double label_x { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double label_y { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ne_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string wikidataid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_ar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_bn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_de { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_en { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_es { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_fa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_fr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_el { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_he { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_hi { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_hu { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_it { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_ja { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_ko { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_nl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_pl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_pt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_ru { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_sv { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_tr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_uk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_ur { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string name_vi { get; set; }
        /// <summary>
        /// 哥斯达黎加
        /// </summary>
        public string name_zh { get; set; }
        /// <summary>
        /// 哥斯大黎加
        /// </summary>
        public string name_zht { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_iso { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string tlc_diff { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_tlc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_us { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_fr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_ru { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_es { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_cn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_tw { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_in { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_np { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_pk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_de { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_gb { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_br { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_il { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_ps { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_sa { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_eg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_ma { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_pt { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_ar { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_jp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_ko { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_vn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_tr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_pl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_gr { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_it { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_nl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_se { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_bd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string fclass_ua { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string filename { get; set; }
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
        public object coordinates { get; set; }
        //public List<List<List<double>>> coordinates { get; set; }
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
        /// 
        [Newtonsoft.Json.JsonIgnore]
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
        /// 
        [Newtonsoft.Json.JsonIgnore]
        public string type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<FeaturesItem> features { get; set; }
    }
}


public class CustomJson : MonoBehaviour
{
    public TextAsset json;
    void Start()
    {

        List<Guid> guids = new List<Guid>();
        List<List<Vector2>> postions = new List<List<Vector2>>();

        CustomJ.Root root = JsonConvert.DeserializeObject<CustomJ.Root>(json.text);
        foreach (CustomJ.FeaturesItem feature in root.features)
        {
            //print((List<List<List<double>>>)feature.geometry.coordinates);
            try
            {
                List<List<List<double>>> list1 = ConvertToList<List<List<double>>>(feature.geometry.coordinates);
                foreach (List<List<double>> item1 in list1)
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
            }
            catch
            {
                List<List<List<List<double>>>> list2 = ConvertToList<List<List<List<double>>>>(feature.geometry.coordinates);
                foreach (List<List<List<double>>> item1 in list2)
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
            //MapDrawer.CreateBaseMap(postions, .1f, Color.black, Color.blue, false, .2f);
        }
        //ReadData(postions);
        guids = MapDrawer.CreateBaseMap(postions, .1f, Color.black, Color.blue, false, .2f);

    }
    public static List<T> ConvertToList<T>(object obj)
    {
        // 检查 object 是否可以转换为 JArray
        if (obj is Newtonsoft.Json.Linq.JArray jArray)
        {
            return jArray.ToObject<List<T>>();
        }

        // 检查 object 是否可以直接转换为 List<T>
        if (obj is List<T> list)
        {
            return list;
        }

        // 尝试将 object 作为 IEnumerable<T> 进行转换
        if (obj is IEnumerable<object> enumerable)
        {
            try
            {
                List<T> result = new List<T>();
                foreach (var item in enumerable)
                {
                    if (item is T tItem)
                    {
                        result.Add(tItem);
                    }
                    else
                    {
                        // 尝试进行类型转换
                        T convertedItem = (T)Convert.ChangeType(item, typeof(T));
                        result.Add(convertedItem);
                    }
                }
                return result;
            }
            catch
            {
                // 转换失败，返回 null
                return null;
            }
        }

        // 无法转换，返回 null
        return null;
    }

    private void ReadData(List<List<Vector2>> postions)
    {
        try
        {
            model3.Root root = JsonConvert.DeserializeObject<model3.Root>(json.text);
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
        catch
        {
            model4.Root root = JsonConvert.DeserializeObject<model4.Root>(json.text);
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
    }

}






