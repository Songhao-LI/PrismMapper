using System;
using System.Collections.Generic;
using TriangleNet.Geometry;
using UnityEngine;
namespace TriangleNet
{

    public class MapDrawer : MonoBehaviour
    {
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
            mapMaterial.color = mapColor;
            mr.material = mapMaterial;
            go.transform.parent = parent;
            GameObject wall = new GameObject("wall");
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
                item.material.color=color;
            }
        }
        public static void SetLineColor(Guid guid, Color color)
        {
            foreach (var item in GameObject.Find(guid.ToString()).GetComponentsInChildren<LineRenderer>())
            {
                item.material.color=color;
            }
        }
        public static void SetLineWidth(Guid guid, float width)
        {
            foreach (var item in GameObject.Find(guid.ToString()).GetComponentsInChildren<LineRenderer>())
            {
                item.startWidth=width;
                item.endWidth=width;
            }
        }

    }
}