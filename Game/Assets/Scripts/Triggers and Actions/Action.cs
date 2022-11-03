using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] Trigger trigger;
    [SerializeField] bool disableTrigger;
        
    void Start()
    {
        if(disableTrigger) DisableTrigger();
    }
    
    void DisableTrigger()
    {
        trigger.enabled = false;
    }
}