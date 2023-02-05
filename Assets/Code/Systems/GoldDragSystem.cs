using Code.Components;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    public class GoldDragSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _inputFilter = null;
        private EcsFilter<GoldComponent> _goldFilter = null;
        private SharedState _sharedState;

        public void Run()
        {
            foreach (var i in _inputFilter)
            {
                ref var inputComponent = ref _inputFilter.Get1(i);

                foreach (var j in _goldFilter)
                {
                    ref var goldComponent = ref _goldFilter.Get1(j);

                    if (goldComponent.isDragging)
                    {
                        if (inputComponent.isDragging)
                        {
                            Drag(ref goldComponent);
                        }
                        else
                        {
                            goldComponent.isDragging = false;
                            _sharedState.releasedGoldId = goldComponent.id;
                        }
                    }
                }
            }
        }

        private void Drag(ref GoldComponent goldComponent)
        {
            var transform = goldComponent.transform;
            transform.parent = _sharedState.canvas.transform;
            transform.SetAsLastSibling();
            transform.position = Input.mousePosition;
        }
    }
}