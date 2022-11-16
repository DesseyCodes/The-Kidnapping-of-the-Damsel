using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Trigger.cs can't be used by itself. 
// It just provides base functionality for triggers.

public class Trigger : MonoBehaviour
{
    [SerializeField] Action[] actions;
    [SerializeField] bool repeat;
    int actionIndex;
    protected bool canTrigger = true;

    protected void EnableAction()
    {
        if (actions[0] == null || actions.Length == 0)
            Debug.Log(gameObject.name + ": No actions set to this trigger");
            
        else if(canTrigger)
        {
            canTrigger = false;
            actionIndex = 0;
            actions[0].enabled = true;
        }
    }
    public void ContinueSequence()
    {
        // Actions are repeated using Unity's OnEnable method, so they are repeated by disabling and re-enabling them later.
        if(repeat)
            actions[actionIndex].enabled = false;

        if(actionIndex + 1 < actions.Length)
        {
            actionIndex++;
            actions[actionIndex].enabled = true;
        }
        else if (repeat)
            canTrigger = true;
        else
            enabled = false;
    }
}