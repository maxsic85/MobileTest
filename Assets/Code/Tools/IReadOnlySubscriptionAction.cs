using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReadOnlySubscriptionAction 
{
    void SubscribeOnChange(Action subscribeAction);
    void UnSubscribeOnChange(Action unSubscribeAction);

}
