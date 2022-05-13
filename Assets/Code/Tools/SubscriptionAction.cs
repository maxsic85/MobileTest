using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscriptionAction : IReadOnlySubscriptionAction
{
    private Action _action;

    public void Invoke()
    {
        _action?.Invoke();
    }
    public void SubscribeOnChange(Action subscribeAction)
    {
        _action += subscribeAction;
    }

    public void UnSubscribeOnChange(Action unSubscribeAction)
    {
        _action -= unSubscribeAction;
    }


}
