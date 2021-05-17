using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform _target;
    
    Camera _camera;
    
    void Start()
    {
        _camera = GetComponent<Camera>();
    }
}
