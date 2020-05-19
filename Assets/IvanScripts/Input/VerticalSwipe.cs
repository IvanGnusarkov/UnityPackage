using UnityEngine;

namespace IvanScripts {
    public class VerticalSwipe : Swipe {
        private readonly float completePixelLength;

        public VerticalSwipe(float completePixelLength, Swipeable target) : base(target) {
            this.completePixelLength = completePixelLength;
        }

        protected override float calculatePercent() {
            return (startPosition.y - Input.mousePosition.y) / completePixelLength;
        }
    }
}