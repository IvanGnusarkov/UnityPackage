using UnityEngine;

public static class RaycastUtils {

    public static Transform raycastObject(Camera camera) {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit)) {
            return hit.transform;
        }

        return null;
    }

    public static RaycastHit? rayCastHit(Camera camera) {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit)) {
            return hit;
        }

        return null;
    }

    public static Vector3? raycastPosition(Camera camera) {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit)) {
            return hit.point;
        }

        return null;
    }

    public static Vector3? raycastPositionWith(Camera camera, float? x = null, float? y = null, float? z = null) {
        Vector3? position = raycastPosition(camera);
        if (!position.HasValue) {
            return null;
        }
        Vector3 result = position.Value;

        if (x.HasValue) result.x = x.Value;
        if (y.HasValue) result.y = y.Value;
        if (z.HasValue) result.z = z.Value;
        return result;
    }
}