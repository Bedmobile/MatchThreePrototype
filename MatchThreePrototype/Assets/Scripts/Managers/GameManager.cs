using UnityEngine;

namespace MatchThreePrototype {
    public class GameManager : Manager {

        private static GameManager _instance;
        public static GameManager Instance {
            get {
                return _instance;
            }
        }

        public PoolManager PoolManager;

        private void Awake() {
            if (_instance == null) {
                _instance = this;
            }
            Init();
        }

        public override void Init() {
            PoolManager.Init();
        }
    }
}
