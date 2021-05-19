using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] float _delay = 10f;
    [SerializeField] float _holeSpeed = 10f;

    Vector3 _destination = new Vector3(0, 51, 0);
    
    void FixedUpdate()
    {
        if (_delay >= 0)
        {
            _delay -= PauseTimeManager.deltaTime;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _destination, 
                _holeSpeed * PauseTimeManager.deltaTime);
        }
    }

    public bool HoleUp()
    {
        return (transform.position == _destination);
    }

    public float HoleVerticalPosition()
    {
        return transform.position.y;
    }
}
