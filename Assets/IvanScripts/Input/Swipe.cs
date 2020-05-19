using UnityEngine;

namespace IvanScripts {
    public abstract class Swipe {
        private readonly Swipeable target;

        protected Vector3 startPosition;

        protected Swipe(Swipeable target) {
            this.target = target;
            setStartPosition(Input.mousePosition);
        }

        public void setStartPosition(Vector3 mousePosition) {
            startPosition = mousePosition;
        }

        public void onSwipeContinue() {
            target.onSwipeContinue(calculatePercent());   
        }

        protected abstract float calculatePercent();
    }
}