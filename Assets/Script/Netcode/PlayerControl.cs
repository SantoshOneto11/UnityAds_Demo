using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
public class PlayerControl : NetworkBehaviour
{
    [SerializeField]
    private float speed = 5f;
    Vector3 touchPos;

    void Update()
    {
        if (!IsOwner) return;

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(xInput, yInput, 0).normalized;
        transform.Translate(speed * Time.deltaTime * moveDirection);
        MobileMovement();
    }

    void MobileMovement()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
                {
                    touchPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10f));
                    transform.position = Vector3.MoveTowards(transform.position, touchPos, speed * Time.deltaTime);
                }
            }
        }
    }

}
