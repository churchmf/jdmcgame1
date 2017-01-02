using UnityEngine;
using System.Collections.Generic;

namespace Assets.Hexagons
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class HexagonMesh : MonoBehaviour
    {
        private Mesh m_Mesh;
        private List<Vector3> m_Vertices;
        private List<int> m_Triangles;

        public void Awake()
        {
            GetComponent<MeshFilter>().mesh = m_Mesh = new Mesh();
            m_Vertices = new List<Vector3>();
            m_Triangles = new List<int>();
        }

        public void Triangulate(HexagonCell[] cells)
        {
            m_Mesh.Clear();
            m_Vertices.Clear();
            m_Triangles.Clear();

            for (int i = 0; i < cells.Length; i++)
            {
                Triangulate(cells[i]);
            }

            m_Mesh.vertices = m_Vertices.ToArray();
            m_Mesh.triangles = m_Triangles.ToArray();
            m_Mesh.RecalculateNormals();
        }

        private void Triangulate(HexagonCell cell)
        {
            Vector3 center = cell.transform.localPosition;
            for (int i = 0; i < 6; i++)
            {
                    AddTriangle(
                    center,
                    center + HexagonCell.Corners[i],
                    center + HexagonCell.Corners[i+1]
                );
            }
        }

        private void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            int vertexIndex = m_Vertices.Count;

            m_Vertices.Add(v1);
            m_Vertices.Add(v2);
            m_Vertices.Add(v3);

            m_Triangles.Add(vertexIndex);
            m_Triangles.Add(vertexIndex + 1);
            m_Triangles.Add(vertexIndex + 2);
        }
    }
}
