using UnityEngine;

namespace TicTacToe.Scripts.MonoBehaviors
{
    public class ContentReferences : MonoBehaviour
    {
        [SerializeField] private GameObject cross;
        [SerializeField] private GameObject zero;

        public GameObject Cross => cross;
        public GameObject Zero => zero;
    }
}
