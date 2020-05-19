namespace IvanScripts {
    public interface Swipeable : Tappable {
        Swipe onSwipeStart();
        void onSwipeContinue(float percent);
    }
}