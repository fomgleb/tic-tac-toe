using Leopotam.Ecs;
using TicTacToe.Scripts.Components.Events;
using TicTacToe.Scripts.Components.References;
using TicTacToe.Scripts.Data;
using TicTacToe.Scripts.MonoBehaviors;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TicTacToe.Scripts.Systems
{
    public class InteractableRestartButtonSystem : IEcsRunSystem
    {
        private readonly EcsFilter<RestartButtonClickedEvent> _restartButtonClickedEvents = null;
        private readonly EcsFilter<CellContentChangedEvent> _cellContentChangedEvents = null;
        private readonly SceneData _sceneData = null;

        public void Run()
        {
            foreach (var entityIndex in _restartButtonClickedEvents)
            {
                ref var buttonEntity = ref _restartButtonClickedEvents.GetEntity(entityIndex);
                var buttonGameObject = buttonEntity.Get<GameObjectReference>().GameObject;

                buttonGameObject.GetComponent<Button>().interactable = false;
                SceneManager.LoadScene("MainScene");
            }

            foreach (var entityIndex in _cellContentChangedEvents)
            {
                ref var buttonEntity = ref _sceneData.RestartButton.GetComponent<EntityReference>().Entity;
                var buttonGameObject = buttonEntity.Get<GameObjectReference>().GameObject;
                var restartButton = buttonGameObject.GetComponent<Button>();

                if (!restartButton.interactable)
                    buttonGameObject.GetComponent<Button>().interactable = true;
            }
        }
    }
}