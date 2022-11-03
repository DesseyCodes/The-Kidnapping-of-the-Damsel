using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] bool disableTrigger;
    
    void Start()
    {
        Trigger trigger = GetComponent<Trigger>();
        
        if(disableTrigger) DisableTrigger(trigger);
    }
    
    void DisableTrigger(Trigger trigger)
    {
        trigger.enabled = false;
    }
}