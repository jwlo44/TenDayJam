using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class UIAnimPulse : MonoBehaviour
{
    public RectTransform target;
    public float minScale = 1;
    public float maxScale = 1;
    public float speed = 0.1f;
    float interpolateAmount = 0f;
    bool bScalingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float smoothAmount = 1 - Mathf.Cos(interpolateAmount * Mathf.PI) / 2;
        float currentScale = (minScale * (1 - smoothAmount)) + (maxScale * smoothAmount);
        target.localScale = Vector3.one * currentScale;
        interpolateAmount += bScalingUp ? speed : -speed;
        if (bScalingUp && interpolateAmount >= 1)
        {
            bScalingUp = false;
        }
        else if (bScalingUp && interpolateAmount <= 0)
        {
            bScalingUp = true;
        }
    }
}
