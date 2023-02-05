using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Systems
{
    public class CheckCellClickSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _checkingClickFilter = null;

        public void Run()
        {
            foreach (var i in _checkingClickFilter)
            {
                ref var inputComponent = ref _checkingClickFilter.Get1(i);

                inputComponent.cellClickedId = 0;

                if (!inputComponent.isClicked) return;

                foreach (RaycastResult result in inputComponent.clickResults)
                {
                    var uiElement = result.gameObject;

                    inputComponent.cellClickedId = uiElement.transform.GetSiblingIndex() + 1;
                    
                    Debug.Log(inputComponent.cellClickedId);
                }
            }
        }
    }
}