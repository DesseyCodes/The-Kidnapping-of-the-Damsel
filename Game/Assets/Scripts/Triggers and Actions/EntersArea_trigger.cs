using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntersArea_trigger : Trigger
{
    [SerializeField] string gameObjectTag;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == gameObjectTag)
            EnableAction();
    }
}