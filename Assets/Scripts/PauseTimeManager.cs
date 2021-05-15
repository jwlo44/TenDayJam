using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTimeManager
{
    public static float localTimeScale = 1;

    public static float timeScale
    {
        get
        {
            return Time.timeScale * localTimeScale;
        }
    }

    public static float deltaTime
    {
        get
        {
            return Time.deltaTime* timeScale;
        }
    }
    
}
