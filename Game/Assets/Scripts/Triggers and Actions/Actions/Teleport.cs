using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Teleports a tagged game object to a new position.
public class Teleport : Action
{
    [SerializeField] string gameObjectTag;
    [SerializeField] Transform newPosition;
    
    void OnEnable()
    {
        GameObject.FindWithTag(gameObjectTag).transform.position = newPosition.position;
        SignalToContinue();
    }
}
