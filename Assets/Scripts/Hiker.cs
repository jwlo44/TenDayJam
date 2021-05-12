using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiker : MonoBehaviour
{
    [SerializeField] float _hikeSpeed;
    [SerializeField] float _maxHeight;

    void Start()
    {
        if (_hikeSpeed <= 0)
        {
            _hikeSpeed = 1;
        }
    }

    void FixedUpdate()
    {
        if(ShouldGoUp())
            transform.Translate(Time.deltaTime * _hikeSpeed * Vector3.up);
    }

    bool ShouldGoUp()
    {
        if (transform.position.y < _maxHeight)
            return true;
        return false;
    }
}