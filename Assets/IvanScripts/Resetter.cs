using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using IvanScripts.Lang;
using UnityEngine;

internal struct ObjectInfo {
    public GameObject go;
    public Vector3 position;
    public Quaternion rotation;
}

public class Resetter: Singleton<Resetter> {
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

    public void resetSmoothly(float delay, float duration) {
        StartCoroutine(resetSmoothlyCoroutine(delay, duration));
    }

    private IEnumerator resetSmoothlyCoroutine(float delay, float duration) {
        yield return new WaitForSecondsRealtime(delay);
        foreach (ObjectInfo info in infos) {
            Transform tr = info.go.transform;
            tr.DOMove(info.position, duration);
            tr.DORotate(info.rotation.eulerAngles, duration);
        }

        yield return null;
    }
}