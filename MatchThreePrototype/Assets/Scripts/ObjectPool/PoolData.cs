using System;
using UnityEngine;

namespace MatchThreePrototype {
    [Serializable]
    public class PoolData {
        public GameObject PooledObjectPrefab;
        public int AmountInstances;

        public void IncreaseAmount() {
            AmountInstances += 1;
        }
    }
}