using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] float _distanceFromObject;
    [SerializeField] float _maxDistanceFromCamera;
    [SerializeField] float _slapStunDuration;
    [SerializeField] Animator _transformAnimator;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject _lookTarget;

    AudioSource _audioSource;
    Camera _camera;
    float _depth;
    RaycastHit _hit;
    Ray _ray;
    bool _randomSlapBool;
    Collider _collider;

    void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.enabled = false;
        _camera = Camera.main;
        _audioSource = GetComponent<AudioSource>();

        if (_slapStunDuration <= 0)
        {
            _slapStunDuration = 2;
        }

        _depth = _distanceFromObject;
        var slapAnimController = _transformAnimator.GetBehaviour<SlapAnimController>();
        slapAnimController.OnIdle += OnSlapFinished;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _audioSource.Play();
            _animator.SetTrigger("Slap");
            _randomSlapBool = new System.Random().Next(100) <= 50;
            if (_randomSlapBool)
            {
                _transformAnimator.SetTrigger("Slap");
            }
            else
            {
                _transformAnimator.SetTrigger("BackSlap");
            }
            _collider.enabled = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other == null || !other.gameObject.CompareTag("Hiker"))
        {
            return;
        }
        Hiker hiker = other.GetComponent<Hiker>();
        if (hiker == null)
        {
            return;
        }
        hiker.SlapMe(_slapStunDuration);
    }

    void OnSlapFinished()
    {
        _collider.enabled = false;
    }

    void FixedUpdate()
    {
        UpdateDepth();
        transform.position = GetWorldPosition(_camera, _depth);
        transform.LookAt(_lookTarget.transform);
    }

    void UpdateDepth()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            _depth = _hit.distance - _distanceFromObject;
        }
    }

    Vector2 GetBoundedScreenPosition()
    {
        float xClamp = Mathf.Clamp(Input.mousePosition.x, 0, Screen.width - 1);
        float yClamp = Mathf.Clamp(Input.mousePosition.y, 0, Screen.height - 1);

        return new Vector2(xClamp, yClamp);
    }

    Vector3 GetWorldPosition(Camera camera, float worldDepth)
    {
        Vector2 screenPos = GetBoundedScreenPosition();
        Vector3 screenPosWithDepth = new Vector3(screenPos.x, screenPos.y, worldDepth);
        return camera.ScreenToWorldPoint(screenPosWithDepth);
    }
}
