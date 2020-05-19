using DG.Tweening;
using UnityEngine;

namespace IvanScripts {
    public static class Shaker {
        public static void shake(GameObject gameObject, float duration, float strength = 20f) {
            gameObject.transform.DOShakeRotation(duration, strength: strength);
        }

        public static void shakeZ(GameObject gameObject, float duration, float strength = 20f) {
            gameObject.transform.DOShakeRotation(duration, Vector3.forward * strength);
        }
    }
}