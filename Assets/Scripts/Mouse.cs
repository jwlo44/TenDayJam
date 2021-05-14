using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] float _distanceFromObject;
    [SerializeField] float _maxDistanceFromCamera;
    [SerializeField] float _slapStunDuration;
    
    Camera _camera;
    float _depth;
    RaycastHit _hit;
    Ray _ray;

    void Start()
    {
        // Turn off cursor when G O D H A N D is in town
        
        
        _camera = Camera.main;
        if (_distanceFromObject == 0)
        {
            _distanceFromObject = 2;
        }

        if (_slapStunDuration <= 0)
        {
            _slapStunDuration = 2;
        }

        _depth = _distanceFromObject;
    }

    void Update()
    {
        // Check to see if you are clicking on a hiker
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (_hit.collider.gameObject.CompareTag("Hiker"))
            {
                Hiker hiker = _hit.collider.GetComponent<Hiker>();
                hiker.SlapMe(_slapStunDuration);

                Debug.Log("Clicked on a hiker");
            }
        }

        // Toggle cursor 
        if (Input.GetKeyDown("space"))
        {
            Cursor.visible = !Cursor.visible;
        }
        
    }

    void FixedUpdate()
    {
        UpdateDepth();
        transform.position = GetWorldPosition(_camera, _depth);
    }

    void UpdateDepth()
    {
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
}
