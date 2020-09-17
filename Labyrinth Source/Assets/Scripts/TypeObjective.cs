using UnityEngine;

namespace Labyrinth
{
    public class TypeObjective : MonoBehaviour, IInteractable
    {
        public bool IsInteractable { get; private set; } = true;


        public void Interact(Transform instigator)
        {
            if (!IsInteractable) return;
            if (instigator.IsNull()) return;

            var inventory = instigator.GetComponent<Inventory>();
            if (inventory.IsNotNull())
                inventory.AddToInventory(this.gameObject);

            gameObject.SetActive(false);
            IsInteractable = false;
        }


        public void CancelInteraction() => IsInteractable = false;
    }
}