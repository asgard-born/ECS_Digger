using Code.Components;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Code.Systems
{
    public class CellsHandleClickSystem : IEcsRunSystem
    {
        private EcsFilter<InputComponent> _canvasFilter = null;

        public void Run()
        {
            foreach (var i in _canvasFilter)
            {
                ref var canvasComponent = ref _canvasFilter.Get1(i);

                foreach (RaycastResult result in canvasComponent.clickResults)
                {
                    GameObject ui_element = result.gameObject;
                    Debug.Log(ui_element.name);
                }
            }
        }
    }
}