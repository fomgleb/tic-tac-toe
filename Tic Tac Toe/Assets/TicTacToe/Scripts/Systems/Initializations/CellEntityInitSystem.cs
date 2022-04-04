using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.References;
using TicTacToe.Scripts.Components.Requests;
using TicTacToe.Scripts.Components.Tags;

namespace TicTacToe.Scripts.Systems.Initializations
{
    public class CellEntityInitSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InitializeCellEntityRequest> _initializeCellRequestsFilter = null;

        public void Init()
        {
            foreach (var entityIndex in _initializeCellRequestsFilter)
            {
                ref var cellEntity = ref _initializeCellRequestsFilter.GetEntity(entityIndex);
                ref var initializeCellRequest = ref _initializeCellRequestsFilter.Get1(entityIndex);

                ref var cellTag = ref cellEntity.Get<CellTag>();
                ref var cellPositionComponent = ref cellEntity.Get<CellPositionComponent>();
                ref var cellContentComponent = ref cellEntity.Get<CellContentComponent>();
                ref var gameObjectReference = ref cellEntity.Get<GameObjectReference>();

                cellPositionComponent.CellPosition = initializeCellRequest.CellPosition;
                cellContentComponent.Content = CellEnum.Empty;
            }
        }
    }
}