using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.Log("Disabled trigger");
        trigger.enabled = false;
    }
}