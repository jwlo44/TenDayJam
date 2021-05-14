using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiker : MonoBehaviour
{
    [SerializeField] float _hikeSpeed;
    [SerializeField] Transform _mountainTop;

    float _timeUntilMoveAgain = 0f;
    
    void Start()
    {
        if (_hikeSpeed <= 0)
        {
            _hikeSpeed = 1;
        }
    }

    void Update()
    {
        if (_timeUntilMoveAgain > 0)
            _timeUntilMoveAgain -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (ShouldGoUp())
            GoUpTheMountain();
    }

    bool ShouldGoUp()
    {
        if (_timeUntilMoveAgain <= 0)
            return true;
        
        return false;
    }

    void GoUpTheMountain()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mountainTop.position, _hikeSpeed * Time.deltaTime);
    }

    public void SlapMe(float seconds)
    {
        _timeUntilMoveAgain = seconds;
    }
    
}