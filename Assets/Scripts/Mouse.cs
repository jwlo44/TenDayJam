using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    Vector2 _mousePosition;
    float _mouseX;
    float _mouseY;

    Vector3 _handPosition;

    Camera _camera;

    void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        _mousePosition = Input.mousePosition;

        //if (Input.GetMouseButtonDown(0))
        //{
            /*
            _mouseX = _mousePosition.x;
            _mouseY = _mousePosition.y;
            Debug.Log($"Mouse X: {_mouseX}, Mouse Y: {_mouseY}");
            */

            _handPosition = GetWorldPosition(_camera, 2);
            transform.position = _handPosition;
        //}
    }

    Vector2 GetBoundedScreenPosition()
    {
        float xClamp = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width - 1);
        float yClamp = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height - 1);

        return new Vector2(xClamp, yClamp);
    }

    Vector3 GetWorldPosition(Camera camera, float worldDepth)
    {
        Vector2 screenPos = GetBoundedScreenPosition();
        Vector3 screenPosWithDepth = new Vector3(screenPos.x, screenPos.y, worldDepth);
        return camera.ScreenToWorldPoint(screenPosWithDepth);
    }

    Vector3 GetWorldPosition(Camera camera)
    {
        Debug.Log(camera.nearClipPlane);
        return GetWorldPosition(camera, camera.nearClipPlane);
    }
    
}
