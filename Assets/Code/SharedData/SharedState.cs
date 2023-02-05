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
        public int goldSpawned;
        public int goldBarsCount;
        public int paddlesCount;
        public int releasedGoldId = -1;
        
        public bool isSpawningGold;

        public MainConfigs mainConfigs => _mainConfigs;
        public CellState[] cellsState => _cellsState;
        public Canvas canvas => _canvas;
        public bool hasFinished;

        public struct Context
        {
            public MainConfigs mainConfigs;
            public Canvas canvas;
        }

        public SharedState(Context ctx)
        {
            _mainConfigs = ctx.mainConfigs;
            _canvas = ctx.canvas;
            _cellsState = new CellState[mainConfigs.gridSize * mainConfigs.gridSize];
            paddlesCount = mainConfigs.paddlesCount;
        }
    }
}