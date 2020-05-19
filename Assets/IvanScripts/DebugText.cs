using IvanScripts.Lang;
using UnityEngine.UI;

public class DebugText : Singleton<DebugText> {
    private Text textComponent;

    public static void debug(string text) {
        getInstance().debugInternal(text);
    }

    private void Start() {
        textComponent = GetComponent<Text>();
    }

    private void debugInternal(string text) {
        textComponent.text = text;
    }
}