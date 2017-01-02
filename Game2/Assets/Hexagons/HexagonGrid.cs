using UnityEngine;
using UnityEngine.UI;

namespace Assets.Hexagons
{
    // http://catlikecoding.com/unity/tutorials/hex-map-1/
    public class HexagonGrid : MonoBehaviour
    {
        public int Width = 6;
        public int Height = 6;

        public HexagonCell CellPrefab;
        private HexagonCell[] m_Cells;

        public HexagonMesh HexagonMesh;

        // debug display
        public Text CellLabelPrefab;
        public Canvas GridCanvas;

        public void Awake()
        {
            // debug display
            GridCanvas = GetComponentInChildren<Canvas>();

            HexagonMesh = GetComponentInChildren<HexagonMesh>();

            m_Cells = new HexagonCell[Height * Width];

            for (int z = 0, i = 0; z < Height; z++)
            {
                for (int x = 0; x < Width; x++)
                {
                    CreateCell(x, z, i++);
                }
            }
        }

        public void Start()
        {
            HexagonMesh.Triangulate(m_Cells);
        }

        private void CreateCell(int x, int z, int i)
        {
            var position = new Vector3()
            {
                x = (x + z * 0.5f - z / 2) * (HexagonCell.InnerRadius * 2f),
                y = 0f,
                z = z * (HexagonCell.OuterRadius * 1.5f)
            };

            HexagonCell cell = m_Cells[i] = Instantiate<HexagonCell>(CellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
            cell.Coordinates = HexagonCoordinates.FromOffsetCoordinates(x, z);

            // debug display
            Text label = Instantiate<Text>(CellLabelPrefab);
            label.rectTransform.SetParent(GridCanvas.transform, false);
            label.rectTransform.anchoredPosition =
                new Vector2(position.x, position.z);
            label.text = cell.Coordinates.ToStringOnSeparateLines();
        }
    }
}
