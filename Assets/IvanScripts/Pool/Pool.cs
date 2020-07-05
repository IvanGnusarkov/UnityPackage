using System.Collections.Generic;
using IvanScripts.Lang;
using UnityEngine;

namespace IvanScripts {
    public class Pool<P, T>: Singleton<P> where P:MonoBehaviour where T : Component {
        public T prefab;
        private List<T> freeObjects;
        private List<T> aliveObjects;

        protected override void Awake() {
            freeObjects = new List<T>();
            aliveObjects = new List<T>();
        }

        public void destroy(T t) {
            t.gameObject.SetActive(false);
            freeObjects.Add(t);
        }
        
        public void destroyAll() {
            foreach (T t in aliveObjects) {
                t.gameObject.SetActive(false);
                freeObjects.Add(t);
            } 
            aliveObjects.Clear();
        }

        public T create(Vector3 position, Quaternion rotation, Transform container) { 
            T result;
            if (freeObjects.Count > 0) {
                result = freeObjects[0];
                freeObjects.Remove(result);

                Transform resultTransform = result.transform;
                resultTransform.position = position;
                resultTransform.rotation = rotation;
                resultTransform.parent = container;
                result.gameObject.SetActive(true);
            } else {
                result = Instantiate(prefab, position, rotation, container).GetComponent<T>();
            } 
            aliveObjects.Add(result);
            return result;
        }
    }
}