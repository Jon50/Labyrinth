using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Labyrinth
{
    public class InteractCaster : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _interactText;
        [SerializeField] private Image _crosshair;
        [SerializeField] private LayerMask _layer;

        private void Update()
        {
            if (Physics.SphereCast(transform.position - transform.forward, 0.2f, transform.forward, out RaycastHit hitInfo, 3f, _layer))
            {
                var interactable = hitInfo.transform.GetComponent<IInteractable>();
                if (interactable.IsInteractable == false || interactable == null) { return; }

                if (Input.GetMouseButtonDown(0))
                    interactable.Interact(this.transform.parent); //TODO: Cache the parent to be more efficient and readable.

                _interactText.enabled = true;
                _crosshair.rectTransform.sizeDelta = new Vector2(8, 8);
            }
            else
            {
                _interactText.enabled = false;
                _crosshair.rectTransform.sizeDelta = new Vector2(5, 5);
            }
        }


#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(transform.position - transform.forward, transform.position + transform.forward * 3f);

            if (Physics.SphereCast(transform.position - transform.forward, 0.2f, transform.forward, out RaycastHit hitInfo, 3f, _layer))
                Gizmos.DrawSphere(hitInfo.point, 0.2f);
        }
#endif
    }
}