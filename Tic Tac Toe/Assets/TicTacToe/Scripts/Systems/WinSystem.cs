using System.Collections.Generic;
using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Data;
using TicTacToe.Scripts.Extensions;
using UnityEngine;

namespace TicTacToe.Scripts.Systems
{
    public class WinSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CellPositionComponent, CellContentComponent, CellContentChangedEvent> _cellContentChangedEventsFilter = null;
        private readonly EcsWorld _world = null; 
        private readonly Configuration _configuration = null;
        private readonly RuntimeData _runtimeData = null;

        public void Run()
        {
            foreach (var entityIndex in _cellContentChangedEventsFilter)
            {
                ref var cellPositionComponent = ref _cellContentChangedEventsFilter.Get1(entityIndex);
                ref var cellContentComponent = ref _cellContentChangedEventsFilter.Get2(entityIndex);
                ref var winLineLenght = ref _configuration.gameBoardWinLineLenght; 

                ref var positionOfClickedCell = ref cellPositionComponent.CellPosition;
                ref var contentOfClickedCell = ref cellContentComponent.Content;
                ref var gameBoard = ref _runtimeData.GameBoard;

                var horizontalWinLine =
                    GetCellContentLine(gameBoard.GetLine(positionOfClickedCell.y), contentOfClickedCell);
                if (horizontalWinLine.Count >= winLineLenght)
                    _world.NewEntity().Get<WinEvent>().WinLine = horizontalWinLine;

                var verticalWinLine =
                    GetCellContentLine(gameBoard.GetColumn(positionOfClickedCell.x), contentOfClickedCell);
                if (verticalWinLine.Count >= winLineLenght)
                    _world.NewEntity().Get<WinEvent>().WinLine = verticalWinLine;

                var leftDiagonalWinLine = GetCellContentLine(gameBoard.GetLeftDiagonal(positionOfClickedCell),
                    contentOfClickedCell);
                if (leftDiagonalWinLine.Count >= winLineLenght)
                    _world.NewEntity().Get<WinEvent>().WinLine = leftDiagonalWinLine;

                var rightDiagonalWinLine = GetCellContentLine(gameBoard.GetRightDiagonal(positionOfClickedCell),
                    contentOfClickedCell);
                if (rightDiagonalWinLine.Count >= winLineLenght)
                    _world.NewEntity().Get<WinEvent>().WinLine = rightDiagonalWinLine;
            }
        }

        private List<EcsEntity> GetCellContentLine(EcsEntity[] line, CellEnum contentToCheck)
        {
            var lineStarted = false;
            var cellContentLine = new List<EcsEntity>();

            for (var x = 0; x < line.Length; x++)
            {
                if (line[x].Get<CellContentComponent>().Content == contentToCheck)
                {
                    lineStarted = true;
                    cellContentLine.Add(line[x]);
                }
                else if (lineStarted)
                    break;
            }

            return cellContentLine;
        }
    }
}