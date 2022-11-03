using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField] Action action;
    
    protected void EnableAction()
    {
        action.enabled = true;
    }
}