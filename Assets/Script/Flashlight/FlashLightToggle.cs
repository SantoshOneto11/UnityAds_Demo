using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightToggle : MonoBehaviour
{
    private bool isTorchOn = false;
    private AndroidJavaObject cameraManager;
    public static FlashLightToggle instance;
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            AndroidJavaClass cameraClass = new AndroidJavaClass("android.hardware.Camera");
            cameraManager = cameraClass.CallStatic<AndroidJavaObject>("getCameraInfo");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // You can change this to any trigger you prefer
        {
            ToggleTorch();
        }
    }

    public void ToggleTorch()
    {
        if (cameraManager != null)
        {
            if (isTorchOn)
            {
                cameraManager.Call("setFlashMode", 0); // 0 for off
            }
            else
            {
                cameraManager.Call("setFlashMode", 1); // 1 for on
            }

            isTorchOn = !isTorchOn;
        }
    }
}
