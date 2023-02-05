using Code.Components;
using Code.SharedData;
using Code.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace Code.Systems
{
    public class LootingSystem : IEcsRunSystem
    {
        private EcsFilter<GoldComponent>.Exclude<HasDestroyedTag> _goldFilter = null;
        private EcsFilter<LootComponent> _lootFilter = null;
        private SharedState _sharedState;

        public void Run()
        {
            foreach (var g in _goldFilter)
            {
                ref var goldComponent = ref _goldFilter.Get1(g);
                ref var goldEntity = ref _goldFilter.GetEntity(g);

                if (_sharedState.releasedGoldId != goldComponent.id) return;

                foreach (var j in _lootFilter)
                {
                    ref var lootComponent = ref _lootFilter.Get1(j);

                    var localMousePosition = lootComponent.rectTransform.InverseTransformPoint(Input.mousePosition);

                    if (lootComponent.rectTransform.rect.Contains(localMousePosition))
                    {
                        LootGold(ref goldEntity, ref goldComponent);
                    }
                    else
                    {
                        ReturnGold(ref goldComponent);
                    }
                }
            }
        }

        private void LootGold(ref EcsEntity goldEntity, ref GoldComponent goldComponent)
        {
            _sharedState.goldBarsCount++;
            Object.Destroy(goldComponent.transform.gameObject);
            _sharedState.releasedGoldId = -1;
            goldEntity.Get<HasDestroyedTag>();
        }

        private void ReturnGold(ref GoldComponent goldComponent)
        {
            _sharedState.releasedGoldId = -1;
            goldComponent.transform.SetParent(goldComponent.parentCell.transform);
            goldComponent.rectTransform.anchoredPosition = Vector2.zero;
        }
    }
}