using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MatchThreePrototype {
    public class PoolManager : Manager {

        public PoolData TilePoolData;
        public Pool TilePool;

        public override void Init() {
            TilePool = new Pool(transform, TilePoolData);
        }
    }
}