using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateGameObject : Action
{
    [SerializeField] GameObject objectToDeactivate;
    [SerializeField] bool deactivate, destroy;
    void Start()
    {
        if(deactivate)
            objectToDeactivate.SetActive(false);
        else if(destroy)
            GameObject.Destroy(objectToDeactivate);
    }
}
