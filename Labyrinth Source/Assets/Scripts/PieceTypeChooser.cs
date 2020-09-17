using UnityEngine;

namespace Labyrinth
{
    public class PieceTypeChooser : MonoBehaviour
    {
#pragma warning disable CS0414
        [SerializeField] private bool _typePlaceholder = false;
        [SerializeField] private bool _typeObjective = false;
        [SerializeField] private bool _clear = false;
        [SerializeField] private Component _previousType = null;
#pragma warning restore CS0414
    }
}
