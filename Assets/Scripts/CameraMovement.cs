using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float _rotateSpeed = 2;

    private void Update()
    {
        if (Input.GetKey("a"))
        {
            transform.Rotate(0, _rotateSpeed * Time.deltaTime, 0);
        }
        else if (Input.GetKey("d"))
        {
            transform.Rotate(0, -_rotateSpeed * Time.deltaTime, 0);
        }
    }
}
