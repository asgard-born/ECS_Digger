using Code.Components;
using Code.SharedData;
using Leopotam.Ecs;

namespace Code.Systems
{
    public class CheckGameFinishSystem : IEcsRunSystem
    {
        private EcsFilter<UIComponent> _uiFilter = null;
        private SharedState _sharedState;

        public void Run()
        {
            if (!HasLootGold() && _sharedState.paddlesCount > 0) return;

            foreach (var i in _uiFilter)
            {
                ref var uiComponent = ref _uiFilter.Get1(i);

                if (_sharedState.paddlesCount <= 0)
                {
                    if (HasLootGold())
                    {
                        WinFinishGame(ref uiComponent);
                    }
                    else
                    {
                        LooseFinishGame(ref uiComponent);
                    }

                    return;
                }

                if (HasLootGold())
                {
                    WinFinishGame(ref uiComponent);
                }
            }
        }

        private bool HasLootGold()
        {
            return _sharedState.goldBarsCount >= _sharedState.mainConfigs.goldCountToDig;
        }

        private void WinFinishGame(ref UIComponent uiComponent)
        {
            _sharedState.hasFinished = true;
            uiComponent.winPanel.SetActive(true);
        }

        private void LooseFinishGame(ref UIComponent uiComponent)
        {
            _sharedState.hasFinished = true;
            uiComponent.loosePanel.SetActive(true);
        }
    }
}