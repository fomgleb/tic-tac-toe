using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Data;

namespace TicTacToe.Scripts.Systems
{
    public class ShowCurrentPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CellContentChangedEvent> _cellContentChangedEventsFilter = null;

        private readonly Configuration _configuration = null;
        private readonly SceneData _sceneData = null;
        private readonly RuntimeData _runtimeData = null;
        
        public void Run()
        {
            foreach (var entityIndex in _cellContentChangedEventsFilter)
            {
                ref var zeroSprite = ref _configuration.zeroSprite;
                ref var crossSprite = ref _configuration.crossSprite;
                var currentPlayerImage = _sceneData.CurrentPlayerImage;
                ref var currentPlayer = ref _runtimeData.CurrentPlayer;

                switch (currentPlayer)
                {
                    case CellEnum.Cross:
                        currentPlayerImage.sprite = crossSprite;
                        break;
                    case CellEnum.Zero:
                        currentPlayerImage.sprite = zeroSprite;
                        break;
                }
            }

        }
    }
}