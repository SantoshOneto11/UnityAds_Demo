using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.onButtonClick += TeleportNow;
    }

    private void OnDisable()
    {
        EventManager.onButtonClick -= TeleportNow;
    }

    public void TeleportNow()
    {
        Vector3 pos = transform.position;
        pos.y = Random.Range(1.0f, 3.0f);
        transform.position = pos;
    }
}
