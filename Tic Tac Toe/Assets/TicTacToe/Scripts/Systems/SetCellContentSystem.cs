using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.Blocks;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Data;

namespace TicTacToe.Scripts.Systems
{
    public class SetCellContentSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CellContentComponent, CellMouseDownEvent>.Exclude<BlockTheTap> _cellMouseDownEventsFilter = null;

        private readonly RuntimeData _runtimeData = null;

        public void Run()
        {
            foreach (var entityIndex in _cellMouseDownEventsFilter)
            {
                ref var cellEntity = ref _cellMouseDownEventsFilter.GetEntity(entityIndex);
                ref var cellContentComponent = ref _cellMouseDownEventsFilter.Get1(entityIndex);

                if (cellContentComponent.Content == CellEnum.Empty)
                {
                    cellContentComponent.Content = _runtimeData.CurrentPlayer;
                    cellEntity.Get<CellContentChangedEvent>();
                }
            }
        }
    }
}