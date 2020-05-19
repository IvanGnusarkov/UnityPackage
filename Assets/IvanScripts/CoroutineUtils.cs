using System;
using System.Collections.Generic;
using UnityEngine;

namespace IvanScripts {
    public static class CoroutineUtils {
        public static IEnumerator<WaitForSecondsRealtime> delay(float seconds, Action action) {
            yield return new WaitForSecondsRealtime(seconds);
            action();
            yield return null;
        }
    }
}