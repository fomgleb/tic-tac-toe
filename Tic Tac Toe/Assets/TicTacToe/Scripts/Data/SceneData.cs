using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.Scripts.Data
{
    public class SceneData : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private Image currentPlayerImage;
        [SerializeField] private Button restartButton;

        public Camera MainCamera => mainCamera;
        public Image CurrentPlayerImage => currentPlayerImage;
        public Button RestartButton => restartButton;
    }
}