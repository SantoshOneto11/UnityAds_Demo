using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    public Transform target; // The target for the camera to follow
    public float smoothSpeed = 0.125f; // The speed of the smoothing
    public Vector3 offset; // The offset of the camera relative to the target

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not set for the SmoothCameraFollow script.");
            return;
        }

        // Desired position based on target position and offset
        Vector3 desiredPosition = target.position + offset;

        // Smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera position to the smoothed position
        transform.position = smoothedPosition;

        // Optionally, make the camera look at the target
        transform.LookAt(target);
    }
}

