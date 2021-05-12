using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiker : MonoBehaviour
{
    [SerializeField] float _hikeSpeed;

    void Start()
    {
        if (_hikeSpeed <= 0)
        {
            _hikeSpeed = 1;
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Time.deltaTime * _hikeSpeed * Vector3.up);
    }
}
