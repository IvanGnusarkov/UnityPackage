using UnityEngine;

namespace IvanScripts {
    public class DiagonalSwipe : Swipe {
        private readonly float length;

        public DiagonalSwipe(Swipeable target, float length) : base(target) {
            this.length = length;
        }

        protected override float calculatePercent() {
            Vector3 start = startPosition;
            Vector3 now = Input.mousePosition;
            Vector3 diff = start - now;
            return diff.magnitude / length;
        }
    }
}