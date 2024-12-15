using ProjNet.CoordinateSystems.Transformations;
using ProjNet.CoordinateSystems;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using TriangleNet.Geometry;
using UnityEngine;
using UnityEngine.Internal;
using DotSpatial.Projections;
namespace TriangleNet
{

    public class MapDrawer : MonoBehaviour
    {
        public static List<Guid> CreateBaseMap(List<List<Vector2>> positions, float height, Color mapColor, Color lineColor, bool needLine, float lineWidth)
        {
            List<Guid> guids = new List<Guid>();
            foreach (var position in positions)
            {
                guids.Add(DrawMap(position, height, mapColor, lineColor, needLine, lineWidth));
            }
            return guids;
        }
        public static Guid DrawMap(List<Vector2> positions, float height, Color mapColor, Color lineColor, bool needLine, float lineWidth)
        {
            Polygon poly = new Polygon();
            poly.Add(positions);
            var triangleNetMesh = (TriangleNetMesh)poly.Triangulate();
            GameObject go = new GameObject("Generated mesh");
            Guid guid = Guid.NewGuid();
            Transform parent = new GameObject(guid.ToString()).transform;
            var mf = go.AddComponent<MeshFilter>();
            var mesh = triangleNetMesh.GenerateUnityMesh();
            mf.mesh = mesh;
            var mr = go.AddComponent<MeshRenderer>();
            Material mapMaterial = Resources.Load<Material>("mapMaterial");
            //mapMaterial.color 
            mr.material = mapMaterial;
            mr.material.color = mapColor;
            go.transform.parent = parent;
            GameObject wall = new GameObject("wall");
            wall.AddComponent<Data>().postions=positions;
            var wall_mf = wall.AddComponent<MeshFilter>();
            var wall_mr = wall.AddComponent<MeshRenderer>();
            wall_mr.material = mapMaterial;
            wall.transform.parent = parent;
            List<Vector3> vertices = new List<Vector3>();
            int index = 0;
            for (int i = 0; i < positions.Count; i++)
            {

                if (index == 0)
                {
                    vertices.Add(new Vector3(positions[index][0], 0, positions[index][1]));
                    vertices.Add(new Vector3(positions[index][0], height, positions[index][1]));
                    vertices.Add(new Vector3(positions[index + 1][0], 0, positions[index + 1][1]));
                }
                else if (index == positions.Count - 1)
                {
                    vertices.Add(new Vector3(positions[index - 1][0], 0, positions[index - 1][1]));
                    vertices.Add(new Vector3(positions[index][0], height, positions[index][1]));
                    vertices.Add(new Vector3(positions[index][0], 0, positions[index][1]));
                }
                else
                {
                    vertices.Add(new Vector3(positions[index - 1][0], height, positions[index - 1][1]));
                    vertices.Add(new Vector3(positions[index][0], height, positions[index][1]));
                    vertices.Add(new Vector3(positions[index][0], 0, positions[index][1]));
                    vertices.Add(new Vector3(positions[index][0], 0, positions[index][1]));
                    vertices.Add(new Vector3(positions[index][0], height, positions[index][1]));
                    vertices.Add(new Vector3(positions[index + 1][0], 0, positions[index + 1][1]));
                }
                index++;
            }
            Mesh wallMesh = new Mesh();
            wallMesh.vertices = vertices.ToArray();
            List<int> triangles = new();
            for (int i = 0; i < vertices.Count; i++)
            {
                triangles.Add(i);
            }
            wallMesh.triangles = triangles.ToArray();
            wallMesh.RecalculateNormals();
            wall_mf.mesh = wallMesh;
            wall_mr.material = Resources.Load<Material>("WallMaterial");
            wall_mr.material.color = mapColor;
            wall.transform.Rotate(0, 0, 0);
            go.transform.Rotate(90, 0, 0);
            Instantiate(go, parent).transform.Translate(0, 0, -height);
            if (needLine)
            {
                LineRenderer linerender = Instantiate(Resources.Load<GameObject>("Line"), parent).GetComponent<LineRenderer>();
                linerender.positionCount = positions.Count;
                linerender.SetWidth(lineWidth, lineWidth);
                for (int i = 0; i < positions.Count; i++)
                {
                    linerender.SetPosition(i, new Vector3(positions[i][0], positions[i][1], 0.1f));
                }
                linerender.material.color = lineColor;
                linerender.transform.Rotate(90, 0, 0);
                linerender.transform.Translate(0, 0, -0.1f);
                Instantiate(linerender, parent).transform.Translate(0, 0, -height);
            }
            return guid;

        }
        public static void Delete(Guid guid)
        {
            Destroy(GameObject.Find(guid.ToString()));
        }
        public static void SetBlockColor(Guid guid, Color color)
        {
            foreach (var item in GameObject.Find(guid.ToString()).GetComponentsInChildren<MeshRenderer>())
            {
                item.material.color = color;
            }
        }
        public static void SetLineColor(Guid guid, Color color)
        {
            foreach (var item in GameObject.Find(guid.ToString()).GetComponentsInChildren<LineRenderer>())
            {
                item.material.color = color;
            }
        }
        public static void SetLineWidth(Guid guid, float width)
        {
            foreach (var item in GameObject.Find(guid.ToString()).GetComponentsInChildren<LineRenderer>())
            {
                item.startWidth = width;
                item.endWidth = width;
            }
        }
        public static Guid AddPrismMap(Guid guid, float height,Color color)
        {
            List<Vector2> vector2s = new List<Vector2>();
            foreach (var item in GameObject.Find(guid.ToString()).transform.GetChild(0).GetComponent<MeshFilter>().mesh.vertices)
            {
                vector2s.Add(new Vector2(item[0], item[1]));
            }
            return DrawMap(GameObject.Find(guid.ToString()).GetComponentInChildren<Data>().postions, height, color, color, false, 0);
        }
        public static Guid AddPrismMap(Guid guid, float height)
        {
            List<Vector2> vector2s = new List<Vector2>();
            Transform firstChild = GameObject.Find(guid.ToString()).transform.GetChild(0);
            foreach (var item in firstChild.GetComponent<MeshFilter>().mesh.vertices)
            {
                vector2s.Add(new Vector2(item[0], item[1]));
            }
            return DrawMap(GameObject.Find(guid.ToString()).GetComponentInChildren<Data>().postions, height,firstChild.GetComponent<MeshRenderer>().material.color, Color.black, false, 0);
        }
        public static double[] TransformCoordinates(double[] fromPoint)
        {

             // Mercator Projection
             // 创建坐标转换工厂
             CoordinateTransformationFactory ctFactory = new CoordinateTransformationFactory();
             // 从 WGS84 (地理坐标) 到 WGS84 / World Mercator
             var geographicCoordinateSystem = GeographicCoordinateSystem.WGS84;
             var projectedCoordinateSystem = ProjectedCoordinateSystem.WebMercator;
             // 创建转换
             var transform = ctFactory.CreateFromCoordinateSystems(geographicCoordinateSystem, projectedCoordinateSystem);
             // 转换一个点
             double[] toPoint = transform.MathTransform.Transform(fromPoint);
             return toPoint;

                        /*
            // Manually define the WGS84 Geographic coordinate system
            ProjectionInfo source = KnownCoordinateSystems.Geographic.World.WGS1984;

            // Manually define an Azimuthal Equidistant projection with the specified center latitude and longitude
            ProjectionInfo destination = new ProjectionInfo();
            destination.ParseEsriString(@"PROJCS[""Azimuthal Equidistant"",
    GEOGCS[""GCS_WGS_1984"",
        DATUM[""D_WGS_1984"",
            SPHEROID[""WGS_1984"",6378137,298.257223563]],
        PRIMEM[""Greenwich"",0],
        UNIT[""Degree"",0.0174532925199433]],
    PROJECTION[""Azimuthal_Equidistant""],
    PARAMETER[""False_Easting"",0],
    PARAMETER[""False_Northing"",0],
    PARAMETER[""Longitude_Of_Center"",0],  // Set the center longitude (e.g., for Australia)
    PARAMETER[""Latitude_Of_Center"", 0],   // Set the center latitude (e.g., for Australia)
    UNIT[""Meter"",1]]");

            // Convert the coordinate
            double[] toPoint = new double[2];
            Array.Copy(fromPoint, toPoint, 2);

            // Perform the transformation
            Reproject.ReprojectPoints(toPoint, null, source, destination, 0, 1);

            return toPoint;
                        */
        }
        public static void AddDotDensityMap(Guid guid,Color color,float radius)
        {
            int segments = 50;
            GameObject circle = new GameObject();
            MeshFilter filter = circle.AddComponent<MeshFilter>();
            MeshRenderer renderer = circle.AddComponent<MeshRenderer>();
            renderer.material = Resources.Load<Material>("Transparent");
            //print(Resources.Load<Material>("Transparent"));
            renderer.material.color = color;
            //renderer.material = Resources.Load<Material>("Transparent");
            Mesh mesh = new Mesh();
            filter.mesh = mesh;

            Vector3[] vertices = new Vector3[segments + 1];
            int[] triangles = new int[segments * 3];

            // Center vertex
            vertices[0] = Vector3.zero;

            // Calculate vertices
            for (int i = 1; i <= segments; i++)
            {
                float angle = (float)i / (float)segments * Mathf.PI * 2f;
                vertices[i] = new Vector3(Mathf.Cos(angle) * radius, 0f, Mathf.Sin(angle) * radius);
            }

            // Calculate triangles
            for (int i = 0; i < segments; i++)
            {
                triangles[i * 3] = 0;
                triangles[i * 3 + 1] = i + 1;
                triangles[i * 3 + 2] = (i + 1) % segments + 1;
            }

            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
            // Optional: Calculate normals
            //Vector3[] normals = new Vector3[vertices.Length];
            //for (int i = 0; i < normals.Length; i++)
            //{
            //    normals[i] = Vector3.down;
            //}
            //mesh.normals = normals;
            circle.transform.localEulerAngles = new Vector3(180, 0, 0);
            circle.transform.SetParent(GameObject.Find(guid.ToString()).transform);

            //print(GameObject.Find(guid.ToString()).transform.GetChild(2).GetComponent<MeshRenderer>().bounds.center);
            circle.transform.position = GameObject.Find(guid.ToString()).transform.GetChild(2).GetComponent<MeshRenderer>().bounds.center+new Vector3(0,0.1f,0);
        }
    }
}