using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : Trigger
{
    [SerializeField] int count;
    [Tooltip ("Triggers an action when the counter reaches 0.\n If unchecked, it will trigger when 'count' is reached.")]
    [SerializeField] bool subtractiveCounter;
    int currentCount;

    void Start()
    {
        if(subtractiveCounter)
            currentCount = count;
        else
            currentCount = 0;
    }

    public void UpdateCounter(int value)
    {
        currentCount += value;
        
        if(subtractiveCounter && currentCount <= 0)
            EnableAction();
        else if(currentCount == count)
            EnableAction();
    }
}
