using Leopotam.Ecs;
using TicTacToe.Scripts.Components.Events;
using UnityEngine;

namespace TicTacToe.Scripts.MonoBehaviors
{
    public class CellClicksHandler : MonoBehaviour
    {
        private void OnMouseDown()
        {
            GetComponent<EntityReference>().Entity.Get<CellMouseDownEvent>();
        }
    }
}
