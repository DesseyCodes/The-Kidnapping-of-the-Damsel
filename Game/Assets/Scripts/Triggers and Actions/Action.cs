using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Action.cs and Trigger.cs can't be used by themselves.

public class Action : MonoBehaviour
{
    [SerializeField] bool disableTrigger;
        
    void Start()
    {
        if(disableTrigger)
        {
            Trigger trigger = GetComponent<Trigger>();
            DisableTrigger(trigger);
        }
    }
    
    void DisableTrigger(Trigger trigger)
    {
        trigger.enabled = false;
    }
}