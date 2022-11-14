using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Trigger : MonoBehaviour
{
    [SerializeField] Action[] actions;
    [SerializeField] bool repeat;
    int actionIndex;
    protected bool canStart = true;

    protected void EnableAction()
    {
        if (actions[0] == null || actions.Length == 0)
            Debug.Log(gameObject.name + ": No actions set to this trigger");
            
        else if(canStart)
        {
            actionIndex = 0;
            actions[0].enabled = true;
        }
    }
    public void ContinueSequence()
    {
        if(repeat)
            actions[actionIndex].enabled = false;

        if(actionIndex + 1 < actions.Length)
        {
            actionIndex++;
            actions[actionIndex].enabled = true;
            canStart = false;
        }
        else if (!repeat)
            enabled = false;
        else
            canStart = true;
    }
}