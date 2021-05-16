using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiker : MonoBehaviour
{
    [SerializeField] float _hikeSpeed;
    [SerializeField] Transform _mountainTop;
    [SerializeField] AudioClip _slapReact;
    [SerializeField] AudioClip _spawn;

    AudioSource _audioSource;
    float _timeUntilMoveAgain = 0f;
    
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _spawn;
        if (_hikeSpeed <= 0)
        {
            _hikeSpeed = 1;
        }
    }

    void Update()
    {
        if (_timeUntilMoveAgain > 0)
            _timeUntilMoveAgain -= PauseTimeManager.deltaTime;
    }

    void FixedUpdate()
    {
        if (ShouldGoUp())
            GoUpTheMountain();
    }

    bool ShouldGoUp()
    {
        return _mountainTop != null && _timeUntilMoveAgain <= 0;
    }

    void GoUpTheMountain()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mountainTop.position, _hikeSpeed * PauseTimeManager.deltaTime);
    }

    public void SlapMe(float seconds)
    {
        _audioSource.clip = _slapReact;
        _audioSource.Play();
        _timeUntilMoveAgain = seconds;
    }
    
}