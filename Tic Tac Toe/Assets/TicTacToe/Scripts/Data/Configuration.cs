using UnityEngine;

namespace TicTacToe.Scripts.Data
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        [Header("Game Board")]
        [Range(2, 100)] public int gameBoardWidth;
        [Range(2, 100)] public int gameBoardHeight;
        [Range(2, 100)] public int gameBoardWinLineLenght;
        public float indentBetweenCells;
        public Vector2 positionOfLeftTopCell;
        public GameObject cellPrefab;
        public Sprite zeroSprite;
        public Sprite crossSprite;
    }
}