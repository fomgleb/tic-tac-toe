using Leopotam.Ecs;
using TicTacToe.Scripts.Components.Events;
using UnityEngine;

namespace TicTacToe.Scripts.MonoBehaviors
{
    public class RestartButtonClicksHandler : MonoBehaviour
    {
        public void ButtonClick()
        {
            GetComponent<EntityReference>().Entity.Get<RestartButtonClickedEvent>();
        }
    }
}
