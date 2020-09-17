using System;
using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class ObjectiveCompleteTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;
        [SerializeField] private List<GameObject> _triggerables;

        // private int _placeholderCount = 0;
        // private int _completedCount = 0;


        private void OnTriggerEnter(Collider other) => CheckObjectiveCompletion();


        private void CheckObjectiveCompletion()
        {
            var extents = GetComponent<Collider>().bounds.extents * 0.5f;
            var raycastHits = Physics.BoxCastAll(transform.position, extents, transform.forward, transform.rotation, 0.1f, _layer);
            var holdersCount = Array.FindAll(raycastHits, holder => holder.transform.GetComponent<TypePlaceHolder>());
            var holders = new TypePlaceHolder[holdersCount.Length];

            for (int i = 0; i < holdersCount.Length; i++)
            {
                holders[i] = holdersCount[i].transform.GetComponent<TypePlaceHolder>();
            }

            if (Array.TrueForAll(holders, condition => condition.IsCompleted == true))
                foreach (var trigger in _triggerables)
                    trigger.GetComponent<ITriggerable>().Trigger();
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            for (int i = 0; i < _triggerables.Count; i++)
            {
                if (RemoveNull()) continue;

                var interfaceType = _triggerables[i].GetComponent<ITriggerable>();
                if (interfaceType.IsNull())
                {
                    _triggerables[i] = null;
                }

                if (RemoveNull()) continue;

                bool RemoveNull()
                {
                    if (_triggerables[i] == null)
                    {
                        _triggerables.RemoveAt(i);
                        i--;
                        return true;
                    }
                    return false;
                }
            }
        }
#endif
    }
}