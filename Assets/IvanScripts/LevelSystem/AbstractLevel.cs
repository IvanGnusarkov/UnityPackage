using UnityEngine;

namespace IvanScripts.LevelSystem {
    public abstract class AbstractLevel : MonoBehaviour {
        private int id;

        public void setId(int newId) {
            id = newId;
        }

        public int getId() {
            return id;
        }

        public abstract bool isComplete();
    }
}