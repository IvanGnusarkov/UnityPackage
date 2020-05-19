using DG.Tweening;
using UnityEngine;

namespace IvanScripts {
    public static class MinimalistUtils {
        public static readonly int TOP = Shader.PropertyToID("_Color1_T");

        public static Tween doColor(Material material, int colorPropertyId, Color color, float duration) {
            return material.DOColor(color, colorPropertyId, duration);
        }
    }
}