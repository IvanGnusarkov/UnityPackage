using IvanScripts.LevelSystem;
using UnityEditor;
using UnityEngine;

namespace IvanScripts.Editor {
    [CustomEditor(typeof(AbstractLevelManager<>), true, isFallback = true)]
    public class LevelManagerEditor : UnityEditor.Editor {
        public override void OnInspectorGUI() {
            DrawDefaultInspector();

            if (GUILayout.Button("Switch")) {
                int currentLevel = serializedObject.FindProperty("currentLevel").intValue; 
                Transform transform = ((Component) target).transform;
                for (int i = 0; i < transform.childCount; i++) {
                    transform.GetChild(i).gameObject.SetActive(currentLevel == i);
                }
            }
        }
    }
}