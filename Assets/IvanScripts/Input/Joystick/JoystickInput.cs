using IvanScripts.Lang;
using UnityEngine;
using UnityEngine.Events;

namespace IvanScripts {
    public class JoystickInput : Singleton<JoystickInput> {
        public JoystickMoveEvent onJoystickMove;
        public UnityEvent onFingerReleased;
        private Vector3? startPosition;
        private Camera cam;

        protected override void Awake() {
            base.Awake();
            cam = Camera.main;
        }

        private void Update() {
            if (Input.GetMouseButtonDown(0)) {
                startPosition = RaycastUtils.raycastPositionWith(cam, y: 1);
            }

            if (Input.GetMouseButton(0)) { 
                Vector3? position = RaycastUtils.raycastPositionWith(cam, y: 1);
                if (position.HasValue) {
                    onJoystickMove.Invoke(position.Value);
                }
            }

            if (Input.GetMouseButtonUp(0)) {
                startPosition = null;
                onFingerReleased.Invoke();
            }
        }

        public static void addAngleListener(UnityAction<Vector3> listener) {
            getInstance().onJoystickMove.AddListener(listener);
        }

        public static void addFingerReleasedListener(UnityAction listener) {
            getInstance().onFingerReleased.AddListener(listener);
        }
    }
}