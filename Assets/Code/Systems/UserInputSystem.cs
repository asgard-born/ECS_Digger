using System.Collections.Generic;
using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Systems
{
    public sealed class UserInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<InputComponent> _canvasFilter = null;
        private PointerEventData _clickData;

        public void Init()
        {
            _clickData = new PointerEventData(EventSystem.current);

            foreach (var i in _canvasFilter)
            {
                ref var canvasComponent = ref _canvasFilter.Get1(i);

                canvasComponent.clickResults = new List<RaycastResult>();
            }
        }

        public void Run()
        {
            foreach (var i in _canvasFilter)
            {
                ref var canvasComponent = ref _canvasFilter.Get1(i);

                canvasComponent.clickResults.Clear();

                if (Input.GetMouseButtonDown(0))
                {
                    _clickData.position = Input.mousePosition;

                    canvasComponent.graphicRaycaster.Raycast(_clickData, canvasComponent.clickResults);
                }
            }
        }
    }
}