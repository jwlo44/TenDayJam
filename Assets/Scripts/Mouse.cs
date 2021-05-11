using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] float _distanceFromObject;
    [SerializeField] float _maxDistanceFromCamera;
    
    Camera _camera;
    float _depth;
    RaycastHit _hit;
    Ray _ray;

    void Start()
    {
        _camera = Camera.main;
        if (_distanceFromObject == 0)
        {
            _distanceFromObject = 2;
        }

        _depth = _distanceFromObject;
    }

    void FixedUpdate()
    {
        UpdateDepth();
        transform.position = GetWorldPosition(_camera, _depth);;
    }

    void UpdateDepth()
    {
        // Raycast, determine distance from camera to object, pull it back a bit by _distanceFromObject
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            _depth = _hit.distance - _distanceFromObject;
        }
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
