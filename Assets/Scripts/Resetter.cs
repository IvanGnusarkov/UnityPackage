using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour {
    public string[] resettableObjectsNames;

    private readonly Dictionary<string, GameObject> resettableObjects = new Dictionary<string, GameObject>();
    private readonly Dictionary<string, Vector3> positions = new Dictionary<string, Vector3>();

    private void Start() {
        foreach (string goName in resettableObjectsNames) {
            GameObject go = GameObject.Find(goName);
            resettableObjects.Add(goName, go);
            positions.Add(goName, go.transform.position);
        }
    }

    public void reset() {
        foreach (KeyValuePair<string,GameObject> pair in resettableObjects) {
            pair.Value.transform.position = positions[pair.Key];
        }
    }
}