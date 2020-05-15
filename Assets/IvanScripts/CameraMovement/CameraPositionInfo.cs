using UnityEngine;

namespace IvanScripts.CameraMovement {
    public struct CameraPositionInfo {
        public Vector3 position;
        public Vector3 rotation;

        public CameraPositionInfo(Vector3 position, Vector3 rotation) {
            this.position = position;
            this.rotation = rotation;
        }
    }
}