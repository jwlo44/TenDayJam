using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] Spawner _spawner;
    [SerializeField] Hole _hole;
    [SerializeField] AudioClip _gameOverMusic;
    [SerializeField] AudioSource _bgMusicSource;
    
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
        _bgMusicSource.clip = _gameOverMusic;
        _bgMusicSource.loop = false;
        _bgMusicSource.Play();
        gameEnded = true;
        MainMenu.SetActive(true);
        gameObject.GetComponent<OpenPauseMenu>().enabled = false;
        GameOverScreen.SetActive(true);
        PauseMenu.SetActive(false);
        PauseTimeManager.localTimeScale = 1 - PauseTimeManager.localTimeScale;
    }

    void WinTime()
    {
        gameEnded = true;
        MainMenu.SetActive(true);
        gameObject.GetComponent<OpenPauseMenu>().enabled = false;
        WinScreen.SetActive(true);
        PauseMenu.SetActive(false);
        PauseTimeManager.localTimeScale = 1 - PauseTimeManager.localTimeScale;
    }
}