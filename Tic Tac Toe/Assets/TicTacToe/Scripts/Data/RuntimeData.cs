using Leopotam.Ecs;
using TicTacToe.Scripts.Components;

namespace TicTacToe.Scripts.Data
{
    public class RuntimeData
    {
        public CellEnum CurrentPlayer = CellEnum.Zero;
        public EcsEntity[,] GameBoard;
    }
}