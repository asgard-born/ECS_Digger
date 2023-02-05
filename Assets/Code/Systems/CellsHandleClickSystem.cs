using Code.Components;
using Code.Configs;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    public class CellsHandleClickSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _inputFilter = null;
        private EcsFilter<CellComponent> _cellFilter = null;
        private SharedConfig _sharedConfig;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref InputComponent inputComponent = ref _inputFilter.Get1(i);

                if (!inputComponent.isClicked) return;

                foreach (var j in _cellFilter)
                {
                    ref var cellComponent = ref _cellFilter.Get1(j);

                    if (inputComponent.cellClickedId == cellComponent.id)
                    {
                        HandleClick(cellComponent);

                        return;
                    }
                }
            }
        }

        private void HandleClick(CellComponent cellComponent)
        {
            if (cellComponent.hasGold) return;

            cellComponent.state++;
            
            var gold = Object.Instantiate(_sharedConfig.mainConfigs.goldPrefab, cellComponent.transform);
            gold.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }
}