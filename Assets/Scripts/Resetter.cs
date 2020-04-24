using System.Collections.Generic;
using UnityEngine;

internal struct ObjectInfo {
    public GameObject go;
    public Vector3 position;
    public Quaternion rotation;
}

public class Resetter : MonoBehaviour {
    public List<GameObject> objectsToReset;

    private readonly List<ObjectInfo> infos = new List<ObjectInfo>();

    private void Start() {
        objectsToReset.ForEach(resettableObject => {
            Transform oTransform = resettableObject.transform;
            infos.Add(new ObjectInfo {
                go = resettableObject,
                position = oTransform.position,
                rotation = oTransform.rotation
            });
        });
    }

    public void resetEverything() {
        infos.ForEach(info => {
            GameObject go = info.go;
            Transform goTransform = go.transform;
            goTransform.position = info.position;
            goTransform.rotation = info.rotation;

            Rigidbody goBody = go.GetComponent<Rigidbody>();
            if (goBody != null) {
                goBody.velocity = Vector3.zero;
                goBody.angularVelocity = Vector3.zero;
            }
        });
    }
}