using Code.Components;
using Code.SharedData;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    public class CellHandleClickSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _checkingClickFilter = null;
        private SharedState _sharedState;

        public void Run()
        {
            foreach (var i in _checkingClickFilter)
            {
                ref var inputComponent = ref _checkingClickFilter.Get1(i);

                inputComponent.cellClickedId = -1;

                if (!inputComponent.isClicked) return;

                foreach (var result in inputComponent.clickResults)
                {
                    var uiElement = result.gameObject;

                    if (!uiElement.CompareTag(_sharedState.mainConfigs.cellTag)) return;

                    inputComponent.cellClickedId = uiElement.transform.GetSiblingIndex();

                    Debug.Log(inputComponent.cellClickedId);
                }
            }
        }
    }
}