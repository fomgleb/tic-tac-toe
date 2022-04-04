using Leopotam.Ecs;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Components.References;
using TicTacToe.Scripts.Data;
using UnityEngine;

namespace TicTacToe.Scripts.Systems
{
    public class ShowWinnerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<WinEvent> _winEventsFilter = null;
        private readonly Configuration _configuration = null;

        public void Run()
        {
            foreach (var entityIndex in _winEventsFilter)
            {
                ref var indentBetweenCells = ref _configuration.indentBetweenCells;
                ref var winEvent = ref _winEventsFilter.Get1(entityIndex);
                ref var winLine = ref winEvent.WinLine;

                foreach (var entity in winLine)
                {
                    var gameObject = entity.Get<GameObjectReference>().GameObject;

                    var spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
                    var animator = gameObject.GetComponent<Animator>();
                    
                    animator.SetBool("Won", true);
                }
            }
        }
    }
}