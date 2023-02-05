using System.Collections.Generic;
using Code.Components;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Systems
{
    public sealed class UserInputSystem : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<InputComponent> _canvasFilter = null;
        private PointerEventData _clickData;
        private SharedState _sharedState;

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
                ref var inputComponent = ref _canvasFilter.Get1(i);

                inputComponent.clickResults.Clear();
                inputComponent.isClicked = false;

                if (Input.GetMouseButtonDown(0))
                {
                    _clickData.position = Input.mousePosition;

                    inputComponent.isClicked = true;
                    inputComponent.isHolding = true;
                    inputComponent.graphicRaycaster.Raycast(_clickData, inputComponent.clickResults);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    inputComponent.isHolding = false;
                    inputComponent.isDragging = false;
                    _clickData.position = Vector2.zero;

                    if (_sharedState.isSpawningGold)
                    {
                        _sharedState.isSpawningGold = false;
                    }
                }
            }
        }
    }
}