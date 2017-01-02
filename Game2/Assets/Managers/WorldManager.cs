using Assets.Hexagons;
using UnityEngine;

namespace Assets.Managers
{
    public class WorldManager : MonoBehaviour
    {
        private HexagonGrid m_WorldBuilderPrefab;

        public void Start()
        {
            m_WorldBuilderPrefab = GetComponentInChildren<HexagonGrid>();
        }
    }
}
