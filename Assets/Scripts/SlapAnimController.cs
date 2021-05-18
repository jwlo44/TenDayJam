using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapAnimController : StateMachineBehaviour
{
    public Action OnIdle;

    // OnStateEnter is called before OnStateEnter is called on any state inside this state machine
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsTag("Idle") && OnIdle != null)
        {
            OnIdle.Invoke();
        }
    }
}
