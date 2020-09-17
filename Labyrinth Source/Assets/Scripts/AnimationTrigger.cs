using UnityEngine;

namespace Labyrinth
{
    [RequireComponent(typeof(Animator))]
    public class AnimationTrigger : MonoBehaviour, ITriggerable
    {
        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();
        public void Trigger() => _animator?.SetTrigger("Trigger");
    }
}