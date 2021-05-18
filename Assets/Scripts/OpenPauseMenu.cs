using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    void Pause()
    {
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        PauseTimeManager.localTimeScale = 1 - PauseTimeManager.localTimeScale;
        AudioListener.pause = !AudioListener.pause;
    }

    void OnDestroy()
    {
        PauseTimeManager.localTimeScale = 1;
        AudioListener.pause = false;
    }
}
