using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Action : MonoBehaviour
{
    // + Allow repeating an action.
    [SerializeField] bool disableTrigger;
    [SerializeField] protected bool waitUntilEnd;
    protected bool canSignal = true;
    
    //DisableTrigger must be called by every action because they can't call the base Start().
    protected void DisableTrigger()
    {
        if(disableTrigger)
            GetComponent<Trigger>().enabled = false;
    }
    
    protected void SignalActionSequencer()
    {
        ActionSequencer actionSequencer = GetComponent<ActionSequencer>();

        if(actionSequencer != null)
            actionSequencer.EnableNextAction();
    }
    
    protected IEnumerator WaitToSignal(WaitForSeconds secondsToWait)
    {
        yield return secondsToWait;

        SignalActionSequencer();
    }
}