using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject WinScreen;
    [SerializeField] Spawner _spawner;
    [SerializeField] Hole _hole;

    bool gameEnded = false;
    
    void Update()
    {
        if (gameEnded == true ||
            GameOverScreen == null ||
            WinScreen == null)
        {
            return;
        }
        if (_spawner.AnyHikersUp())
        {
            GameOverTime();
        }
        else if (_hole.HoleUp())
        {
            WinTime();
        }
    }

    void GameOverTime()
    {
        gameEnded = true;
        GameOverScreen.SetActive(true);
    }

    void WinTime()
    {
        gameEnded = true;
        WinScreen.SetActive(true);
    }
}