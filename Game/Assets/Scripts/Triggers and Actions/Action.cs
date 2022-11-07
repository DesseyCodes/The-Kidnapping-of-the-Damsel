using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Action : MonoBehaviour
{
    // + Allow destroying on action end.
    // + Allow repeating an action.
    [SerializeField] bool disableTrigger;
    //[SerializeField] bool destroyOnEnd;
    
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

    /*//Some actions may need a different DestroyOnEnd().
    protected virtual void DestroyOnEnd()
    {
        if(destroyOnEnd)
            Destroy(this);
    }
    */
}