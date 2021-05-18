using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject GameOverScreen;

    // Update is called once per frame
    void Update()
    {
        if (GameOverScreen == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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