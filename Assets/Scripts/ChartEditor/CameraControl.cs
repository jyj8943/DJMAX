using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera mainCamera;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    public float scrollSpeed = 5f;
    public float smoothTime = 0.2f;

    private void Start()
    {
        mainCamera = Camera.main;
        targetPosition = transform.position;
    }

    private void Update()
    {
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");
        // if (wheelInput > 0)
        // {
        //     // 휠을 올렸을 때
        //     
        // }
        // else if (wheelInput < 0)
        // {
        //     // 휠을 내렸을 때
        // }
        if (wheelInput != 0f)
        {
            // 목표 위치 갱신
            targetPosition += new Vector3(0, wheelInput * scrollSpeed, 0);
        }

        // 부드럽게 이동
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
