using System.Linq;
using UnityEngine;

namespace IvanScripts.LevelSystem {
    public class DestroyAllLevel<T> : AbstractLevel where T : Component {
        private T[] targets;

        private void Awake() {
            targets = GetComponentsInChildren<T>(true);
        }

        public override bool isComplete() {
            return targets.All(target => !target.gameObject.activeInHierarchy);
        }
    }
}