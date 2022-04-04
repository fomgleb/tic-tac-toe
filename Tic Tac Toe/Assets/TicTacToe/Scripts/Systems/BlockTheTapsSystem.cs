using Leopotam.Ecs;
using TicTacToe.Scripts.Components.Blocks;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Components.Tags;

namespace TicTacToe.Scripts.Systems
{
    public class BlockTheTapsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WinEvent> _winEventsFilter = null;
        private readonly EcsFilter<CellTag> _cellsFilter = null;

        public void Run()
        {
            foreach (var winEventEntityIndex in _winEventsFilter)
            {
                foreach (var cellEntityIndex in _cellsFilter)
                {
                    ref var cellEntity = ref _cellsFilter.GetEntity(cellEntityIndex);

                    cellEntity.Get<BlockTheTap>();
                }
            }
        }
    }
}