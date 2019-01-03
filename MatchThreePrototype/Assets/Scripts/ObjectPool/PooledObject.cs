using System;
using UnityEngine;

namespace MatchThreePrototype {
    public class PooledObject : MonoBehaviour {
        private Transform _poolTransform;
        public bool IsFree { get; private set; }

        public void SetPoolTransform(Transform poolTransform) {
            _poolTransform = poolTransform;
        }

        public void Spawn(Transform parentTransform) {
            gameObject.SetActive(true);
            transform.parent = parentTransform;
            IsFree = false;
        }

        public void Despawn() {
            gameObject.SetActive(false);
            transform.parent = _poolTransform;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;
            IsFree = true;
        }
    }
}
