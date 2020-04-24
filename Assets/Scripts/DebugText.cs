using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour {
    private static DebugText INSTANCE;
    private Text textComponent;

    public static void debug(string text) {
        INSTANCE.debugInternal(text);
    }

    private void Start() {
        INSTANCE = this;
        textComponent = GetComponent<Text>();
    }

    private void debugInternal(string text) {
        textComponent.text = text;
    }
}