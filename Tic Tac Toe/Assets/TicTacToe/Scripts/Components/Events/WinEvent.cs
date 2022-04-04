using System.Collections.Generic;
using Leopotam.Ecs;

namespace TicTacToe.Scripts.Components.Events
{
    public struct WinEvent
    {
        public List<EcsEntity> WinLine;
    }
}