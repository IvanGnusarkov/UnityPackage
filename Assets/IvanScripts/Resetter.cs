using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using IvanScripts;
using IvanScripts.Lang;
using UnityEngine;

internal struct ObjectInfo {
    public GameObject go;
    public Vector3 localPosition;
    public Quaternion localRotation;
    public Vector3 localScale;
}

public class Resetter: Singleton<Resetter> {
    public List<GameObject> objectsToReset;

    private readonly List<ObjectInfo> infos = new List<ObjectInfo>();

    private void Start() {
        objectsToReset.ForEach(resettableObject => {
            Transform oTransform = resettableObject.transform;
            infos.Add(new ObjectInfo {
                go = resettableObject,
                localPosition = oTransform.localPosition,
                localRotation = oTransform.localRotation,
                localScale = oTransform.localScale
            });
        });
    }

    public void resetInstantlyEverything() {
        infos.ForEach(resetInstantlyByInfo);
    }

    public void resetInstantly(GameObject go) {
        resetInstantlyByInfo(find(go));
    }

    public void resetSmoothly(GameObject go, float delay, float duration) {
        resetSmoothlyByInfo(find(go), delay, duration);
    }

    public void resetSmoothly(float delay, float duration) {
        StartCoroutine(CoroutineUtils.delay(delay, () => {
            foreach (ObjectInfo info in infos) {
                Transform tr = info.go.transform;
                tr.DOMove(info.localPosition, duration);
                tr.DORotate(info.localRotation.eulerAngles, duration);
                tr.DOScale(info.localScale, duration);
            }
        }));
    }

    private void resetInstantlyByInfo(ObjectInfo info) {
        GameObject go = info.go;
        Transform goTransform = go.transform;
        goTransform.localPosition = info.localPosition;
        goTransform.localRotation = info.localRotation;
        goTransform.localScale = info.localScale;

        Rigidbody goBody = go.GetComponent<Rigidbody>();
        if (goBody != null) {
            goBody.velocity = Vector3.zero;
            goBody.angularVelocity = Vector3.zero;
        }
    }

    private void resetSmoothlyByInfo(ObjectInfo info, float delay, float duration) {
        StartCoroutine(CoroutineUtils.delay(delay, () => {
            Transform tr = info.go.transform;
            tr.DOMove(info.localPosition, duration);
            tr.DORotate(info.localRotation.eulerAngles, duration);
            tr.DOScale(info.localScale, duration);
        }));
    }

    private ObjectInfo find(GameObject go) {
        return infos.Find(storedInfo => storedInfo.go == go);
    }
}