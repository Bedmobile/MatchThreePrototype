using System.Collections.Generic;
using UnityEngine;

namespace MatchThreePrototype {
    public class Pool {
        private List<PooledObject> _pooledObjects;
        private Transform _cachedTransform;
        private PoolData _poolData;

        public Pool(Transform poolManager, PoolData setupData) {
            _poolData = setupData;
            InitPool(poolManager);
            for(int i=0; i < setupData.AmountInstances; i++) {
                AddPooledObject(_cachedTransform);
            }
        }

        private void InitPool(Transform parent) {
            _pooledObjects = new List<PooledObject>();
            GameObject pool = new GameObject(_poolData.PooledObjectPrefab.name + "Pool");
            _cachedTransform = pool.transform;
            _cachedTransform.parent = parent;
        }

        private void AddPooledObject(Transform parent) {
            GameObject instanceGameObject = GameObject.Instantiate(_poolData.PooledObjectPrefab, parent);
            PooledObject poolObject = instanceGameObject.AddComponent<PooledObject>();
            poolObject.SetPoolTransform(parent);
            if(_pooledObjects != null) {
                _pooledObjects.Add(poolObject);
                poolObject.Despawn();
            }
            else {
                Debug.LogError("Pool objects list is null");
            }
        }

        private PooledObject GetAdditionalPoolObject() {
            GameObject additionalInstance = GameObject.Instantiate(_pooledObjects[0].gameObject);
            PooledObject poolObject = additionalInstance.GetComponent<PooledObject>();
            poolObject.SetPoolTransform(_cachedTransform);
            _pooledObjects.Add(poolObject);
            _poolData.IncreaseAmount();
            poolObject.Despawn();
            return poolObject;
        }

        public PooledObject GetFreeObject() {
            for(int i = 0; i < _pooledObjects.Count; i++) {
                if (_pooledObjects[i].IsFree) {
                    return _pooledObjects[i];
                }
            }
            Debug.LogWarning("All ojects is used, pool has been expand!");
            return GetAdditionalPoolObject();
        }
    }
}
