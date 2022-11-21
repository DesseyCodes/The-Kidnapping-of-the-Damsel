using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Currently, CounterUpdater only works with a single counter present in a scene.

public class CounterUpdater : MonoBehaviour
{
    [SerializeField] int value;
    Counter counter;

    void Start()
    {
        counter = Object.FindObjectOfType<Counter>();
        
        if(counter == null)
            Debug.Log(gameObject.name + ": No counter was found.");
    }

    void OnDestroy()
    {
        if(counter != null)
            counter.UpdateCounter(value);
    }
}
