using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] Hole _hole;

    void Update()
    {
        if (_spawner.AnyHikersUp())
        {
            Debug.Log("YOU LOSE");
        }
        else if (_hole.HoleUp())
        {
            // Game Over WIN
            Debug.Log("YOU WIN");
        }
    }
    
    
}
