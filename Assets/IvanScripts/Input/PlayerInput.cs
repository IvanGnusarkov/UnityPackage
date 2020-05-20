﻿using System;
using IvanScripts;
using IvanScripts.Lang;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerInput : Singleton<PlayerInput> {
    private Swipe currentSwipe;

    private void onTap(Transform tapTarget) {
        if (tapTarget == null) {
            return;
        }

        Debug.Log($"Tap on {tapTarget.name}");
        Debug.Log("mesh " + tapTarget.GetComponent<MeshFilter>()?.sharedMesh?.name);

        Tappable tappable = tapTarget.GetComponent<Tappable>();
        tappable?.onTap();

        Swipeable swipeable = tapTarget.GetComponent<Swipeable>();
        if (swipeable != null) {
            currentSwipe = swipeable.onSwipeStart();
        }
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            onTap(RaycastUtils.raycastObject(Camera.main));
        }

        if (Input.GetMouseButton(0)) {
            currentSwipe?.onSwipeContinue();
        }

        if (Input.GetMouseButtonUp(0)) {
            currentSwipe = null;
        }
    }
}