using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject MainMenu;

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
        MainMenu.SetActive(!MainMenu.activeSelf);
        PauseMenu.SetActive(PauseMenu.activeSelf);
        PauseTimeManager.localTimeScale = 1 - PauseTimeManager.localTimeScale;
    }

    void OnDestroy()
    {
        PauseTimeManager.localTimeScale = 1;
    }
}
