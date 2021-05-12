using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiker : MonoBehaviour
{
    [SerializeField] float _hikeSpeed;
    [SerializeField] float _maxHeight;
    [SerializeField] Transform _mountainTop;

    void Start()
    {
        if (_hikeSpeed <= 0)
        {
            _hikeSpeed = 1;
        }
    }

    void FixedUpdate()
    {
        //if (ShouldGoUp())
            GoUpTheMountain();
    }

    bool ShouldGoUp()
    {
        if (transform.position.y < _maxHeight)
            return true;
        return false;
    }

    void GoStraightUp()
    {
        transform.Translate(Time.deltaTime * _hikeSpeed * Vector3.up);
    }

    void GoUpTheMountain()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mountainTop.position, _hikeSpeed * Time.deltaTime);
    }
}