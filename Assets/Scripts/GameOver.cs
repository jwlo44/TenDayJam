using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;

    [SerializeField] Spawner _spawner;
    [SerializeField] Hole _hole;

    void Update()
    {
        if (GameOverScreen == null)
        {
            return;
        }
        if (_spawner.AnyHikersUp())
        {
            Debug.Log("YOU LOSE");
            GameOverTime();
        }
        else if (_hole.HoleUp())
        {
            // Game Over WIN
            Debug.Log("YOU WIN");
            GameOverTime();
        }
    }

    void GameOverTime()
    {
        GameOverScreen.SetActive(!GameOverScreen.activeSelf);
        PauseTimeManager.localTimeScale = 1 - PauseTimeManager.localTimeScale;
        AudioListener.pause = !AudioListener.pause;
    }

    void OnDestroy()
    {
        PauseTimeManager.localTimeScale = 1;
        AudioListener.pause = false;
    }
}