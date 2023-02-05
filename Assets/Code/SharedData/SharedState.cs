using Code.Components;
using Code.Configs;
using Code.Essences;
using UnityEngine;

namespace Code.SharedData
{
    public class SharedState
    {
        private MainConfigs _mainConfigs;
        private CellState[] _cellsState;
        private Canvas _canvas;
        public int goldBarsCount;
        public int shovelsCount;

        public MainConfigs mainConfigs => _mainConfigs;
        public CellState[] cellsState => _cellsState;
        public Canvas canvas => _canvas;
        public GoldComponent draggingGold;

        public bool isSpawningGold;

        public SharedState(MainConfigs mainConfigs, Canvas canvas)
        {
            _mainConfigs = mainConfigs;
            _cellsState = new CellState[mainConfigs.gridSize * mainConfigs.gridSize];
            _canvas = canvas;
        }
    }
}