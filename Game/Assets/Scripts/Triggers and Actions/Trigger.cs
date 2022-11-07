using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Trigger : MonoBehaviour
{
    [Tooltip ("If there is an action here, the action sequencer will be ignored.")]
    [SerializeField] Action action;
    [SerializeField] ActionSequencer actionSequencer;

    protected void EnableAction()
    {
        if (action == null || actionSequencer == null)
            Debug.Log(gameObject.name + ": No actions set to this trigger");
        else if(action != null)
            action.enabled = true;
        else
            actionSequencer.enabled = true;
    }
}