using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Action : MonoBehaviour
{
    // + Allow repeating an action.
    [SerializeField] bool disableTrigger;
    [SerializeField] protected bool waitUntilEnd;
    [SerializeField] protected bool allowRepeat;
    protected bool canSignal = true;
    
    //DisableTrigger must be called by every action because they can't call the base Start().
    protected void DisableTrigger()
    {
        if(disableTrigger)
            GetComponent<Trigger>().enabled = false;
    }
    
    protected void SignalSequencer()
    {
        ActionSequencer actionSequencer = GetComponent<ActionSequencer>();

        if(actionSequencer != null)
            actionSequencer.EnableNextAction();
    }
    //Maybe I should combine WaitToSignal() and SignalSequencer().
    protected IEnumerator WaitToSignal(WaitForSeconds secondsToWait)
    {
        yield return secondsToWait;

        SignalSequencer();
    }
    protected void AllowRepeat()
    {
        if(allowRepeat)
            enabled = false;
    }
}