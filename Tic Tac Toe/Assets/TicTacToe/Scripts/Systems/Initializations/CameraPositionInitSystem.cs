using Leopotam.Ecs;
using TicTacToe.Scripts.Data;
using UnityEngine;

namespace TicTacToe.Scripts.Systems.Initializations
{
    public class CameraPositionInitSystem : IEcsInitSystem
    {
        private readonly Configuration _configuration = null;
        private readonly SceneData _sceneData = null;
        
        public void Init()
        {
            var positionOfLeftTopCell = _configuration.positionOfLeftTopCell;
            var gameBoardHeight = _configuration.gameBoardHeight;
            var gameBoardWidth = _configuration.gameBoardWidth;
            var indentBetweenCells = _configuration.indentBetweenCells;
            var mainCamera = _sceneData.MainCamera;

            mainCamera.orthographicSize = gameBoardHeight + (indentBetweenCells * 4);
            mainCamera.transform.position = new Vector3(positionOfLeftTopCell.x + gameBoardWidth / 2f + ((gameBoardHeight - 1) * indentBetweenCells) /2f - 0.5f,
                positionOfLeftTopCell.y - gameBoardHeight / 2f - ((gameBoardHeight - 1) * indentBetweenCells) /2f + 0.5f, mainCamera.transform.position.z);
        }
    }
}