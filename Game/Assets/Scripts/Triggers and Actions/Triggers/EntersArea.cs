using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntersArea : Trigger
{
    [SerializeField] string gameObjectTag;
    
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == gameObjectTag)
            EnableAction();
    }
}