using Leopotam.Ecs;
using TicTacToe.Scripts.Components.Requests;
using TicTacToe.Scripts.Data;
using UnityEngine;

namespace TicTacToe.Scripts.Systems.Initializations
{
    public class GameBoardInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly Configuration _configuration = null;
        private readonly RuntimeData _runtimeData = null;
        
        public void Init()
        {
            ref var gameBoardWidth = ref _configuration.gameBoardWidth;
            ref var gameBoardHeight = ref _configuration.gameBoardHeight;
            ref var gameBoard = ref _runtimeData.GameBoard;
            
            gameBoard = new EcsEntity[gameBoardHeight, gameBoardWidth];

            for (var y = 0; y < gameBoardHeight; y++)
                for (var x = 0; x < gameBoardWidth; x++)
                {
                    var cellEntity = _world.NewEntity();
                    
                    ref var initializeCellEntityRequest = ref cellEntity.Get<InitializeCellEntityRequest>();
                    ref var initializeCellGameObjectRequest = ref cellEntity.Get<InitializeCellGameObjectRequest>();

                    initializeCellEntityRequest.CellPosition = new Vector2Int(x, y);

                    gameBoard[y, x] = cellEntity;
                }
        }
    }
}