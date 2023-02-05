using Code.Components;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    public class LootingSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _inputFilter = null;
        private EcsFilter<LootComponent> _lootFilter = null;
        private SharedState _sharedState;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var inputComponent = ref _inputFilter.Get1(i);

                foreach (var j in _lootFilter)
                {
                    if (inputComponent.isDragging) return;
                    if (_sharedState.draggingGold.Equals(default(GoldComponent))) return;

                    ref var lootComponent = ref _lootFilter.Get1(j);
                    var localMousePosition = lootComponent.rectTransform.InverseTransformPoint(Input.mousePosition);

                    if (lootComponent.rectTransform.rect.Contains(localMousePosition))
                    {
                        LootGold();
                    }
                    else
                    {
                        ReturnGold();
                    }
                }
            }
        }

        private void ReturnGold()
        {
            _sharedState.draggingGold.transform.SetParent(_sharedState.draggingGold.parentCell.transform);
            _sharedState.draggingGold.rectTransform.anchoredPosition = Vector2.zero;
            _sharedState.draggingGold = default;
        }

        private void LootGold()
        {
            Object.Destroy(_sharedState.draggingGold.transform.gameObject);
            _sharedState.draggingGold = default;
            _sharedState.goldBarsCount++;
        }
    }
}