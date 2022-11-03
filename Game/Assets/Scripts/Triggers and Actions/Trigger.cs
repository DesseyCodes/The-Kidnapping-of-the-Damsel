using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Trigger : MonoBehaviour
{
    [SerializeField] Action action;

    protected void EnableAction()
    {
        action.enabled = true;
    }
}