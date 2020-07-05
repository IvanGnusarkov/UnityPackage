using System;
using UnityEngine;

namespace IvanScripts {
    public class DestroyBound<T>: MonoBehaviour where T: Component{
        private Action<T> destroyAction;

        private void OnCollisionEnter(Collision other) {
            destroyAction(other.gameObject.GetComponent<T>());
        }

        public void setAction(Action<T> action) {
            destroyAction = action;
        }
    }
}