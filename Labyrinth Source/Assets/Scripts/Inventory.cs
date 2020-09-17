using System.Collections.Generic;
using UnityEngine;

namespace Labyrinth
{
    public class Inventory : MonoBehaviour
    {
        private Dictionary<string, GameObject> _inventory = new Dictionary<string, GameObject>();


        public void AddToInventory(GameObject obj)
        {
            if (obj.IsNull()) return;
            _inventory.Add(obj.name, obj);
        }


        public void RemoveFromInventory(string key)
        {
            if (string.IsNullOrEmpty(key)) return;

            if (_inventory.ContainsKey(key))
                _inventory.Remove(key);
        }


        public GameObject GetObject(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;

            if (_inventory.ContainsKey(key))
                return _inventory[key];

            return null;
        }
    }
}