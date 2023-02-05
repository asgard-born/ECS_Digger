using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "MainConfigs")]
    public class MainConfigs : ScriptableObject
    {
        [SerializeField] private GameObject _goldPrefab;
        [SerializeField] [Range(0.1f, 1f)] private float _goldPercent;
        [SerializeField] [Range(2, 10)] private int _gridSize;
        [SerializeField] private string _cellTag;

        public GameObject goldPrefab => _goldPrefab;
        public float goldPercent => _goldPercent;
        public int gridSize => _gridSize;
        public string cellTag => _cellTag;
    }
}