using UnityEngine;

namespace IvanScripts {
    public class HorizontalSwipe : Swipe {
        private readonly float completePixelLength;

        public HorizontalSwipe(Swipeable target, float completePixelLength) : base(target) {
            this.completePixelLength = completePixelLength;
        }

        protected override float calculatePercent() {
            return (Input.mousePosition.x - startPosition.x) / completePixelLength;
        }
        
        public override void setPercent(float percent) {
            startPosition = Input.mousePosition + percent * completePixelLength * Vector3.left;
            onSwipeContinue();
        }
    }
}