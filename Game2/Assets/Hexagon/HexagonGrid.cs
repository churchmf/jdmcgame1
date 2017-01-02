using Assets.Hexagon;
using UnityEngine;
using UnityEngine.UI;

namespace Assets
{
    // http://catlikecoding.com/unity/tutorials/hex-map-1/
    public class HexagonGrid : MonoBehaviour
    {
        public int width = 6;
        public int height = 6;

        public HexagonCell cellPrefab;
        private HexagonCell[] cells;

        // debug display
        public Text cellLabelPrefab;
        public Canvas gridCanvas;

        public HexagonMesh hexMesh;

        public void Awake()
        {
            // debug display
            gridCanvas = GetComponentInChildren<Canvas>();

            hexMesh = GetComponentInChildren<HexagonMesh>();

            cells = new HexagonCell[height * width];

            for (int z = 0, i = 0; z < height; z++)
            {
                for (int x = 0; x < width; x++)
                {
                    CreateCell(x, z, i++);
                }
            }
        }

        public void Start()
        {
            hexMesh.Triangulate(cells);
        }

        private void CreateCell(int x, int z, int i)
        {
            Vector3 position;
            position.x = (x + z * 0.5f - z / 2) * (HexagonCell.innerRadius * 2f);
            position.y = 0f;
            position.z = z * (HexagonCell.outerRadius * 1.5f);

            HexagonCell cell = cells[i] = Instantiate<HexagonCell>(cellPrefab);
            cell.transform.SetParent(transform, false);
            cell.transform.localPosition = position;
            cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

            // debug display
            Text label = Instantiate<Text>(cellLabelPrefab);
            label.rectTransform.SetParent(gridCanvas.transform, false);
            label.rectTransform.anchoredPosition =
                new Vector2(position.x, position.z);
            label.text = cell.coordinates.ToStringOnSeparateLines();
        }
    }
}
