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

    Animator _animator;
    AudioSource _audioSource;
    float _timeUntilMoveAgain = 0f;
    Vector3 _startPosition;
    
    void Start()
    {
        
    }

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _spawn;
        _startPosition = GetComponent<Transform>().position;

        if (_hikeSpeed <= 0)
        {
            _hikeSpeed = 1;
        }
        _audioSource.Play();
    }

    void Update()
    {
        if (_timeUntilMoveAgain > 0)
            _timeUntilMoveAgain -= PauseTimeManager.deltaTime;
    }

    void FixedUpdate()
    {
        if (ShouldGoUp())
        {
            GoUpTheMountain();
            _animator.SetBool("Climbing", true);
        }
        else
        {
            SlideDownTheMountain();
            _animator.SetBool("Climbing", false);
        }
    }

    bool ShouldGoUp()
    {
        return _mountainTop != null && _timeUntilMoveAgain <= 0;
    }

    void GoUpTheMountain()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mountainTop.position, 
            _hikeSpeed * PauseTimeManager.deltaTime);
    }

    void SlideDownTheMountain()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, 
            _hikeSpeed * 2 * PauseTimeManager.deltaTime);
    }

    public void SlapMe(float seconds)
    {
        _audioSource.clip = _slapReact;
        _audioSource.Play();
        _timeUntilMoveAgain = seconds;
    }
    
}