using System;
using IvanScripts.Lang;
using UnityEngine;

namespace IvanScripts {
    public abstract class WorldBox<T> : Singleton<WorldBox<T>> where T: Component{
        private const float WIDTH = 2f;
        public Vector3 size;

        private void Start() {
            Vector3 xSize = new Vector3(WIDTH, size.y, size.z) * 2;
            createBound(xSize, Vector3.left * size.x);
            createBound(xSize, Vector3.right * size.x);
            
            Vector3 ySize = new Vector3(size.x, WIDTH, size.z) * 2;
            createBound(ySize, Vector3.up * size.y);
            createBound(ySize, Vector3.down * size.y);

            Vector3 zSize = new Vector3(size.x, size.y, WIDTH) * 2;
            createBound(zSize, Vector3.back * size.z);
            createBound(zSize, Vector3.forward * size.z);
        }

        private void createBound(Vector3 boundSize, Vector3 position) {
            DestroyBound<T> destroyBound = Instantiate(getBoundPrefab(), position, Quaternion.identity, transform);
            destroyBound.transform.localScale = boundSize;
            destroyBound.setAction(getDestroyAction());
        }

        protected abstract DestroyBound<T> getBoundPrefab();

        protected virtual Action<T> getDestroyAction() {
            return component => Destroy(component.gameObject);
        }
    }
}