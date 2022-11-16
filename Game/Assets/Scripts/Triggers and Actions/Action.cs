using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Action.cs can't be used by itself. 
// It just provides base functionality for actions.
// Note that any action left enabled will run when the scene starts.

public class Action : MonoBehaviour
{
    [Tooltip ("Waits until this action ends to start the next one.")]
    [SerializeField] protected bool waitUntilEnd;

    protected void SignalToContinue()
    {
        Trigger trigger = GetComponent<Trigger>();
        
        if(trigger != null)
            trigger.ContinueSequence();
    }

}