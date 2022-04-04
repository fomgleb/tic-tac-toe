using Leopotam.Ecs;
using TicTacToe.Scripts.Components.Blocks;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Components.Requests;
using TicTacToe.Scripts.Data;
using TicTacToe.Scripts.Systems;
using TicTacToe.Scripts.Systems.Initializations;
using UnityEngine;

namespace TicTacToe.Scripts.Startups
{
    public class GameStartup : MonoBehaviour
    {
        [SerializeField] private Configuration configuration;
        [SerializeField] private SceneData sceneData;
        
        private EcsWorld _world;
        private EcsSystems _updateSystems;
        private EcsSystems _fixedUpdateSystems;

        private void Start()
        {
            _world = new EcsWorld();
            _updateSystems = new EcsSystems(_world);
            _fixedUpdateSystems = new EcsSystems(_world);
            
            var runtimeData = new RuntimeData();
            AddSystems();
            AddOneFrames();
            
            _updateSystems.
                Inject(configuration).
                Inject(sceneData).
                Inject(runtimeData);
            
            _updateSystems.Init();
            _fixedUpdateSystems.Init();
        }
        

        private void AddSystems()
        {
            _updateSystems.
                Add(new CameraPositionInitSystem()).
                Add(new RestartButtonEntityInitSystem()).
                Add(new GameBoardInitSystem()).
                Add(new CellEntityInitSystem()).
                Add(new CellGameObjectInitSystem()).
                Add(new SetCellContentSystem()).
                Add(new CellAnimationSystem()).
                Add(new SwitchPlayerSystem()).
                Add(new ShowCurrentPlayerSystem()).
                
                Add(new WinSystem()).
                Add(new ShowWinnerSystem()).
                Add(new BlockTheTapsSystem()).
                
                Add(new InteractableRestartButtonSystem())
                //Add(new RestartGameSystem())
                ;
        }

        private void AddOneFrames()
        {
            _updateSystems.
                OneFrame<InitializeCellEntityRequest>().
                OneFrame<InitializeCellGameObjectRequest>().
                OneFrame<CellMouseDownEvent>().
                OneFrame<CellContentChangedEvent>().
                OneFrame<WinEvent>().
                OneFrame<RestartButtonClickedEvent>()
                ;
        }
        
        private void Update() => _updateSystems.Run();

        private void OnDestroy()
        {
            _updateSystems.Destroy();
            _world.Destroy();
        }
    }
}
