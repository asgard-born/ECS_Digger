using UnityEngine;

namespace Code.Configs
{
    [CreateAssetMenu(fileName = "MainConfigs")]
    public class MainConfigs : ScriptableObject
    {
        [SerializeField] private GameObject _goldPrefab;
        [SerializeField] [Range(0.1f, 1f)] private float _goldPercent;

        public GameObject goldPrefab => _goldPrefab;
        public float goldPercent => _goldPercent;
    }
}