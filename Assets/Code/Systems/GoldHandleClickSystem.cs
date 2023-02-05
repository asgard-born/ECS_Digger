using Code.Components;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    public class GoldHandleClickSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _inputFilter = null;
        private EcsFilter<GoldComponent> _goldFilter = null;
        private SharedState _sharedState;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var inputComponent = ref _inputFilter.Get1(i);

                if (!inputComponent.isHolding) return;
                if (inputComponent.isDragging) return;
                if (_sharedState.isSpawningGold) return;

                foreach (var j in _goldFilter)
                {
                    ref var goldComponent = ref _goldFilter.Get1(j);
                    var localMousePosition = goldComponent.rectTransform.InverseTransformPoint(Input.mousePosition);

                    if (goldComponent.rectTransform.rect.Contains(localMousePosition))
                    {
                        inputComponent.isDragging = true;
                        _sharedState.draggingGold = goldComponent;
                    }
                }
            }
        }
    }
}