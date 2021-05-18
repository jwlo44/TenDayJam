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
    [SerializeField] GameObject _lookTarget;
    [SerializeField] GameObject _rotateTarget;
    [SerializeField] GameObject _vfx;
    [SerializeField] float _maxHeight;
    [SerializeField] float _fallDownMagnitude = 3;
    
    Animator _animator;
    AudioSource _audioSource;
    float _timeUntilMoveAgain = 0f;
    Vector3 _startPosition;
    GameObject _godHole;
    Transform _rig;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.clip = _spawn;
        _startPosition = GetComponent<Transform>().position;
        _godHole = GameObject.Find("GodHole");
        _rig = gameObject.transform.GetChild(0);
        transform.LookAt(_rotateTarget.transform);

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
        _rig.LookAt(_lookTarget.transform);
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

        if (transform.position.y >= _maxHeight)
        {
            _vfx.SetActive(true);
            _rig.GetChild(0).GetComponent<SkinnedMeshRenderer>().enabled = false;
        }
    }

    bool ShouldGoUp()
    {
        return _mountainTop != null && _timeUntilMoveAgain <= 0 && transform.position.y > _godHole.transform.position.y;
    }

    void GoUpTheMountain()
    {
        transform.position = Vector3.MoveTowards(transform.position, _mountainTop.position, 
            _hikeSpeed * PauseTimeManager.deltaTime);
    }

    void SlideDownTheMountain()
    {
        transform.position = Vector3.MoveTowards(transform.position, _startPosition, 
            _hikeSpeed * _fallDownMagnitude * PauseTimeManager.deltaTime);
    }

    public void SlapMe(float seconds)
    {
        _audioSource.clip = _slapReact;
        _audioSource.Play();
        _timeUntilMoveAgain = seconds;
    }

    public bool AtTheTop()
    {
        return (transform.position == _mountainTop.position);
    }
}