using UnityEngine;

namespace IvanScripts {
    public abstract class Swipe {
        private readonly Swipeable target;

        protected Vector3 startPosition;

        protected Swipe(Swipeable target) {
            this.target = target;
        }

        public void onSwipeContinue() {
            target.onSwipeContinue(calculatePercent());   
        }

        protected abstract float calculatePercent();
        public abstract void setPercent(float percent);
    }
}