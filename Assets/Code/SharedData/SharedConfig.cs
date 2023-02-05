using Code.Configs;
using UnityEngine;

namespace Code.SharedData
{
    public class SharedConfig
    {
        private MainConfigs _mainConfigs;
        public MainConfigs mainConfigs => _mainConfigs;

        public SharedConfig(MainConfigs mainConfigs)
        {
            _mainConfigs = mainConfigs;
        }
    }
}