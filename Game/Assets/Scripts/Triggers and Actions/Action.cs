using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Action : MonoBehaviour
{
    [SerializeField] bool disableTrigger;
    [SerializeField] protected bool waitUntilEnd;
    
    //Included DisableTrigger because the base Start() can't be called.
    protected void DisableTrigger()
    {
        if(disableTrigger)
            GetComponent<Trigger>().enabled = false;
    }

    protected void SignalSequencer()
    {
        Trigger trigger = GetComponent<Trigger>();
        
        if(trigger != null)
            trigger.ContinueSequence();
    }

}