using System.Collections.Generic;
using IvanScripts.Lang;
using UnityEngine;

namespace IvanScripts.LevelSystem {
    public abstract class AbstractLevelManager<T> : Singleton<AbstractLevelManager<T>> where T:AbstractLevel {
        public int currentLevel;
        private List<T> levels;

        protected override void Awake() {
            levels = new List<T>();
            for (int id = 0; id < transform.childCount; id++) {
                T level = transform.GetChild(id).GetComponent<T>();
                level.setId(id);
                level.gameObject.SetActive(currentLevel == level.getId());
                levels.Add(level);
            }
        }

        private T getCurrentLevel() {
            return levels[currentLevel];
        }

        public void checkLevelComplete() {
            if (!getCurrentLevel().isComplete()) {
                return;
            }
            nextLevel();
        }

        private void nextLevel() {
            switchToLevel((currentLevel + 1) % levels.Count);
        }

        private void switchToLevel(int levelId) {
            disableLevel(levels[currentLevel]);
            currentLevel = levelId;
            enableLevel(levels[currentLevel]);
        }

        protected virtual void enableLevel(T level) {
            level.gameObject.SetActive(true); 
        }

        protected virtual void disableLevel(T level) {
            level.gameObject.SetActive(false);
        }
    }
}