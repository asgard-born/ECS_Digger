using Code.Components;
using Code.Providers;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Systems
{
    public class DigSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _inputFilter = null;
        private EcsFilter<CellComponent> _cellFilter = null;
        private SharedState _sharedState;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var inputComponent = ref _inputFilter.Get1(i);

                if (!inputComponent.isClicked) return;

                foreach (var j in _cellFilter)
                {
                    ref var cellComponent = ref _cellFilter.Get1(j);

                    if (inputComponent.cellClickedId == cellComponent.id)
                    {
                        if (!_sharedState.cellsState[cellComponent.id].hasGold)
                        {
                            Dig(ref cellComponent);
                        }

                        inputComponent.cellClickedId = -1;

                        return;
                    }
                }
            }
        }

        private void Dig(ref CellComponent cellComponent)
        {
            _sharedState.paddlesCount--;
            var cellsState = _sharedState.cellsState[cellComponent.id];

            if (cellsState.depthState >= _sharedState.mainConfigs.maxDepth) return;

            cellsState.depthState++;

            var canSpawnGold = Random.Range(0f, 1f) <= _sharedState.mainConfigs.goldPercent;

            if (canSpawnGold)
            {
                SpawnGold(ref cellComponent);
            }
        }

        private void SpawnGold(ref CellComponent cellComponent)
        {
            _sharedState.isSpawningGold = true;

            var gold = Object.Instantiate(_sharedState.mainConfigs.goldPrefab, cellComponent.transform);
            gold.GetComponent<GoldProvider>().Init(cellComponent, _sharedState.goldSpawned);
            gold.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            _sharedState.cellsState[cellComponent.id].hasGold = true;
        }
    }
}