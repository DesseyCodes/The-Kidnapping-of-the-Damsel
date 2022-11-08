using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Action : MonoBehaviour
{
    // + Allow repeating an action.
    [SerializeField] bool disableTrigger;
    [SerializeField] protected bool waitUntilEnd;
    protected float secondsToWait;
    protected bool canSignal;
    
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
    //Currently Update checks instead of WaitUntilEnd coroutine
    protected virtual IEnumerator WaitUntilEnd()
    {
        Debug.Log(gameObject.name + ": base WaitUnitlEnd() was called. secondsToWait is " + secondsToWait);
        yield return new WaitForSeconds(secondsToWait);

        SignalActionSequencer();
    }
}