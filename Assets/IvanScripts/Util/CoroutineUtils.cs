using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IvanScripts {
    public static class CoroutineUtils {
        public static IEnumerator<WaitForSecondsRealtime> delay(float seconds, Action action) {
            yield return new WaitForSecondsRealtime(seconds);
            action();
            yield return null;
        }

        public static IEnumerator<WaitForSecondsRealtime> doMultipleTimes(Action action, int count, float delay, Action endAction) {
            for (int i = 0; i < count; i++) {
                yield return new WaitForSecondsRealtime(delay);
                action();
            }

            endAction();
            yield return null;
        }
    }
}