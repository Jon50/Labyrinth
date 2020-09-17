using UnityEngine;

namespace Labyrinth
{
    public class TypePlaceHolder : MonoBehaviour, IInteractable
    {
        [SerializeField] private Material _material;

        public bool IsCompleted { get; private set; }
        public bool IsInteractable { get; private set; } = true;


        public void Start()
        {
            var renderer = GetComponent<Renderer>();
            renderer.material = _material;
        }


        void IInteractable.Interact(Transform instigator)
        {
            if (instigator.IsNull()) return;

            GameObject objectivePiece = null;
            var inventory = instigator.GetComponent<Inventory>();
            if (inventory.IsNotNull())
            {
                objectivePiece = inventory.GetObject(this.name);
                inventory.RemoveFromInventory(this.name);
            }

            if (objectivePiece.IsNull()) return;

            objectivePiece.SetActive(true);
            objectivePiece.transform.rotation = this.transform.rotation;
            objectivePiece.transform.position = this.transform.position;
            objectivePiece.GetComponent<IInteractable>().CancelInteraction();

            IsCompleted = true;
            IsInteractable = false;

            gameObject.SetActive(false);
        }

        void IInteractable.CancelInteraction() => this.enabled = false;
    }
}