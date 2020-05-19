using DG.Tweening;
using IvanScripts.Lang;
using UnityEngine;

namespace IvanScripts.CameraMovement {
    public abstract class AbstractCameraManager : Singleton<AbstractCameraManager> {
        public Camera cam;

        protected static void moveTo(CameraPositionInfo info, float duration = 2f) {
            Transform cameraTransform = getInstance().cam.transform;
            cameraTransform.DOMove(info.position, duration);
            cameraTransform.DORotate(info.rotation, duration);
        }
    }
}