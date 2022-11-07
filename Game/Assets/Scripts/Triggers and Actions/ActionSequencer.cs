using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSequencer : MonoBehaviour
{
    //Stores a sequence of actions
    //Enables the next action when the previous one ends.
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
