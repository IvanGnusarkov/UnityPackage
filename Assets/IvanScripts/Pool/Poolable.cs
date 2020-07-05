using UnityEngine;

namespace IvanScripts {
    public interface Poolable<P, T> where P:Pool<P, T> where T: Component {
        P getPool();
    }
}