using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.References;
using TicTacToe.Scripts.Components.Requests;
using TicTacToe.Scripts.Data;
using TicTacToe.Scripts.MonoBehaviors;
using UnityEngine;

namespace TicTacToe.Scripts.Systems.Initializations
{
    public class CellGameObjectInitSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InitializeCellGameObjectRequest> _initializeCellGameObjectRequests = null;
        private readonly Configuration _configuration = null;

        public void Init()
        {
            foreach (var entityIndex in _initializeCellGameObjectRequests)
            {
                ref var cellEntity = ref _initializeCellGameObjectRequests.GetEntity(entityIndex);
                ref var cellPositionComponent = ref cellEntity.Get<CellPositionComponent>();

                ref var cellPosition = ref cellPositionComponent.CellPosition;
                ref var positionOfLeftTopCell = ref _configuration.positionOfLeftTopCell;
                ref var indentBetweenCells = ref _configuration.indentBetweenCells;
                ref var cellPrefab = ref _configuration.cellPrefab;

                var gameObjectPosition = new Vector2(positionOfLeftTopCell.x + cellPosition.x + indentBetweenCells * cellPosition.x,
                    positionOfLeftTopCell.y + -cellPosition.y + indentBetweenCells * -cellPosition.y);
                var cellGameObject = Object.Instantiate(cellPrefab, gameObjectPosition, Quaternion.identity);

                cellEntity.Get<GameObjectReference>().GameObject = cellGameObject;
                cellGameObject.GetComponent<EntityReference>().Entity = cellEntity;
            }
        }
    }
}