using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] float _spawnFrequency;
    [SerializeField] Transform _hikerHolder;
    [SerializeField] Hiker _hiker;
    
    Transform[] _spawners;
    Hiker[] _hikers;
    float _countdownToSpawn = 0;
    
    void Start()
    {
        _spawners = GetComponentsInChildren<Transform>();

        if (_spawnFrequency == 0)
            _spawnFrequency = 10f;
    }

    void Update()
    {
        if(ShouldSpawn())
            SpawnHiker();

        _countdownToSpawn -= PauseTimeManager.deltaTime;
    }

    bool ShouldSpawn()
    {
        if (_countdownToSpawn <= 0)
        {
            _countdownToSpawn = _spawnFrequency;
            return true;
        }

        return false;
    }

    void SpawnHiker()
    {
        // Pick a random spawn point
        int spawner = Random.Range(0, _spawners.Length);

        // Spawn a hiker at that position
        Instantiate(_hiker, _spawners[spawner].position, Quaternion.identity, _hikerHolder);
        
        // And add that hiker to the list of hikers
    }
}
