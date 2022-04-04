using Leopotam.Ecs;
using TicTacToe.Scripts.Components;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Components.References;
using TicTacToe.Scripts.MonoBehaviors;

namespace TicTacToe.Scripts.Systems
{
    public class CellAnimationSystem : IEcsRunSystem
    {
        private readonly EcsFilter<CellContentComponent, CellMouseDownEvent> _cellMouseDownEventsFilter = null;

        public void Run()
        {
            foreach (var entityIndex in _cellMouseDownEventsFilter)
            {
                ref var cellEntity = ref _cellMouseDownEventsFilter.GetEntity(entityIndex);
                ref var cellGameObject = ref cellEntity.Get<GameObjectReference>().GameObject;
                ref var cellContentComponent = ref _cellMouseDownEventsFilter.Get1(entityIndex);
                ref var currentContent = ref cellContentComponent.Content;
                var contentReferences = cellGameObject.GetComponent<ContentReferences>();

                if (contentReferences.Cross.activeSelf || contentReferences.Zero.activeSelf) continue;
                
                switch (currentContent)
                {
                    case CellEnum.Cross:
                        contentReferences.Cross.SetActive(true);
                        break;
                    case CellEnum.Zero:
                        contentReferences.Zero.SetActive(true);
                        break;
                }
            }
        }
    }
}