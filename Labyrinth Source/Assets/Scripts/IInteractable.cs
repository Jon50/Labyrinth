using UnityEngine;

namespace Labyrinth
{
    public interface IInteractable
    {
        bool IsInteractable { get; }
        void Interact(Transform instigator);
        void CancelInteraction();
    }
}