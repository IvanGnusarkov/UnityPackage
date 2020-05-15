using UnityEngine;

namespace IvanScripts.Lang {
    public class Singleton<T> : MonoBehaviour where T : Component {
        private static T INSTANCE;

        public static T getInstance() {
            if (INSTANCE == null) {
                Debug.LogError($"Не найден инстанс {typeof(T).FullName}");
            }

            return INSTANCE;
        }

        private void Awake() {
            INSTANCE = this as T;
        }
    }
}