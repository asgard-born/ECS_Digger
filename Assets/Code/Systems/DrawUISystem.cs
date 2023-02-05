using Code.Components;
using Code.SharedData;
using Leopotam.Ecs;

namespace Code.Systems
{
    public class DrawUISystem : IEcsRunSystem
    {
        private SharedState _sharedState;
        private EcsFilter<UIComponent> _uiFilter = null;

        public void Run()
        {
            foreach (var i in _uiFilter)
            {
                ref var uiComponent = ref _uiFilter.Get1(i);

                uiComponent.goldText.text = $"Gold: {_sharedState.goldBarsCount.ToString()}";
                uiComponent.paddlesText.text = $"Paddles: {_sharedState.paddlesCount.ToString()}";
            }
        }
    }
}