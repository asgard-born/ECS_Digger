using Code.Components;
using Leopotam.Ecs;

namespace Code.Systems
{
    public class CellsInitSystem : IEcsInitSystem
    {
        private EcsFilter<CellComponent> _cellsFilter = null;
        
        public void Init()
        {
            var counter = 1;

            foreach (var i in _cellsFilter)
            {
                ref var cellComponent = ref _cellsFilter.Get1(i);
                cellComponent.id = counter;
            }
        }
    }
}