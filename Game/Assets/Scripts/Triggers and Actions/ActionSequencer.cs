using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSequencer : MonoBehaviour
{
    //Stores a sequence of actions.
    //Enables the next action when signaled by the current action.
    //Currently, it can trigger only once.

    [SerializeField] Action[] actions;
    int actionIndex;
    void Start()
    {
        actionIndex = 0;
        actions[0].enabled = true;
    }

    public void EnableNextAction()
    {
        if(actionIndex + 1 < actions.Length)
        {
            actionIndex++;
            actions[actionIndex].enabled = true;
        }
    }
}
