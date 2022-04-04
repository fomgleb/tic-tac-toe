using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Components.References;
using TicTacToe.Scripts.Data;
using TicTacToe.Scripts.MonoBehaviors;
using UnityEngine;

namespace TicTacToe.Scripts.Systems
{
    public class RestartGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RestartButtonClickedEvent> _restartButtonClickedEventsFilter = null;
        private readonly RuntimeData _runtimeData = null;

        public void Run()
        {
            foreach (var entityIndex in _restartButtonClickedEventsFilter)
            {
                ref var currentPlayer = ref _runtimeData.CurrentPlayer;
                ref var gameBoard = ref _runtimeData.GameBoard;

                currentPlayer = CellEnum.Zero;
                foreach (var cellEntity in gameBoard)
                {
                    var cellGameObject = cellEntity.Get<GameObjectReference>().GameObject;
                    var cellAnimator = cellGameObject.GetComponent<Animator>();
                    var cellContentReferences = cellGameObject.GetComponent<ContentReferences>();
                    var crossGameObject = cellContentReferences.Cross;
                    var zeroGameObject = cellContentReferences.Zero;

                    cellAnimator.SetBool("Won", false);
                    crossGameObject.SetActive(false);
                    zeroGameObject.SetActive(false);
                }
            }
        }
    }
}