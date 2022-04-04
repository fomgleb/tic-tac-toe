using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Data;

namespace TicTacToe.Scripts.Systems
{
    public class SwitchPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CellContentChangedEvent> _cellContentChangedEventsFilter = null;
        private readonly RuntimeData _runtimeData = null;

        public void Run()
        {
            foreach (var entityIndex in _cellContentChangedEventsFilter)
            {
                ref var currentPlayer = ref _runtimeData.CurrentPlayer;

                if (currentPlayer == CellEnum.Cross)
                    currentPlayer = CellEnum.Zero;
                else if (currentPlayer == CellEnum.Zero)
                    currentPlayer = CellEnum.Cross;
            }
        }
    }
}