using Code.Components;
using Code.Providers;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Systems
{
    public class GoldSpawningSystem : IEcsRunSystem
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
                        HandleClick(cellComponent);
                        inputComponent.cellClickedId = -1;

                        return;
                    }
                }
            }
        }

        private void HandleClick(CellComponent cellComponent)
        {
            if (_sharedState.cellsState[cellComponent.id].hasGold) return;

            _sharedState.cellsState[cellComponent.id].state++;

            if (true)
            {
                SpawnGold(cellComponent);
            }
        }

        private void SpawnGold(CellComponent cellComponent)
        {
            _sharedState.isSpawningGold = true;

            var gold = Object.Instantiate(_sharedState.mainConfigs.goldPrefab, cellComponent.transform);
            gold.GetComponent<GoldProvider>().Init(cellComponent);
            gold.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            _sharedState.cellsState[cellComponent.id].hasGold = true;
        }
    }
}