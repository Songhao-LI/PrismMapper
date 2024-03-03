using System.Collections.Generic;
using TriangleNet.Geometry;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;
namespace TriangleNet
{
    public class PrismMapper : MonoBehaviour
    {
        private void Start()
        {
            
        }
        public static void DrawMap(List<Vector2> positions,float height,Color mapColor,Color lineColor,bool needLine,float lineWidth)
        {
            print(height);
            Polygon poly = new Polygon();
            poly.Add(positions);
            var triangleNetMesh = (TriangleNetMesh)poly.Triangulate();
            GameObject go = new GameObject("Generated mesh");
            var mf = go.AddComponent<MeshFilter>();
            var mesh = triangleNetMesh.GenerateUnityMesh();
            mf.mesh = mesh;
            var mr = go.AddComponent<MeshRenderer>();
            Material mapMaterial = Resources.Load<Material>("mapMaterial");
            mapMaterial.color = mapColor;
            mr.material = mapMaterial;
            Transform PrismMapper_Trans = FindObjectOfType<PrismMapper>().transform;
            go.transform.parent= PrismMapper_Trans;
            GameObject wall = new GameObject("wall");
            var wall_mf = wall.AddComponent<MeshFilter>();
            var wall_mr = wall.AddComponent<MeshRenderer>();
            wall_mr.material = mapMaterial;
            wall.transform.parent = PrismMapper_Trans;
            List<Vector3> vertices= new List<Vector3>();
            int index = 0;
            for (int i = 0; i < positions.Count; i++) {

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
            Mesh wallMesh= new Mesh();
            wallMesh.vertices = vertices.ToArray();
            List<int> triangles=new();
            for (int i = 0; i < vertices.Count; i++)
            {
                triangles.Add(i);
            }
            wallMesh.triangles = triangles.ToArray();
            wallMesh.RecalculateNormals();
            wall_mf.mesh = wallMesh;
            wall_mr.material = Resources.Load<Material>("WallMaterial");
            wall_mr.material.color=mapColor;
            wall.transform.Rotate(0,0,0);
            go.transform.Rotate(90,0,0);
            Instantiate(go, PrismMapper_Trans).transform.Translate(0,0,-height);
            if (needLine)
            {
                LineRenderer linerender = Instantiate(Resources.Load<GameObject>("Line"), PrismMapper_Trans).GetComponent<LineRenderer>();
                linerender.positionCount = positions.Count;
                linerender.SetWidth(lineWidth,lineWidth);
                for (int i = 0; i < positions.Count; i++)
                {
                    linerender.SetPosition(i, new Vector3(positions[i][0], positions[i][1],0.1f));
                }
                linerender.material.color = lineColor;
                linerender.transform.Rotate(180,0,0);
                linerender.transform.Translate(0,0,-0.1f);
                Instantiate(linerender,PrismMapper_Trans).transform.Translate(0,0,-height);
            }

        }
    }
}