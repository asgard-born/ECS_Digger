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

                if (inputComponent.isDragging)
                {
                    Drag();
                }
            }
        }

        private void Drag()
        {
            var transform = _sharedState.draggingGold.transform;
            transform.parent = _sharedState.canvas.transform;
            transform.SetAsLastSibling();
            transform.position = Input.mousePosition;
        }
    }
}