using UnityEngine;

namespace IvanScripts.Lang {
    public class Singleton<T> : MonoBehaviour where T : Component {
        private static T INSTANCE;

        public static T getInstance() {
            if (INSTANCE != null) {
                return INSTANCE;
            }

            T instance = FindObjectOfType<T>();
            if (instance == null) {
                Debug.LogError($"Не найден инстанс {typeof(T)}");
            } else {
                INSTANCE = instance;
            }

            return INSTANCE;
        }

        protected virtual void Awake() {
            INSTANCE = this as T;
        }
    }
}