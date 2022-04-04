using Leopotam.Ecs;
using TicTacToe.Scripts.Components.References;
using TicTacToe.Scripts.Data;
using TicTacToe.Scripts.MonoBehaviors;

namespace TicTacToe.Scripts.Systems.Initializations
{
    public class RestartButtonEntityInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly SceneData _sceneData = null;
        
        public void Init()
        {
            var restartButtonGameObject = _sceneData.RestartButton.gameObject;
            var restartButtonEntity = _world.NewEntity();

            ref var gameObjectReference = ref restartButtonEntity.Get<GameObjectReference>();

            gameObjectReference.GameObject = restartButtonGameObject;
            
            restartButtonGameObject.GetComponent<EntityReference>().Entity = restartButtonEntity;
        }
    }
}