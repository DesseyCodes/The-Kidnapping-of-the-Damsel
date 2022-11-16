using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Triggers when a game object with the specified tag:
// enters a trigger collider.
// exits a trigger collider.
// stays on a trigger collider and presses a button.

public class AreaTrigger : Trigger
{  
    [Tooltip ("Select one.")]
    [SerializeField] bool enterArea, exitArea, stayInArea;
    [Tooltip ("Tagged game object that will interact with this trigger.")]
    [SerializeField] string gameObjectTag;
    [Tooltip ("Button to be pressed while the game object stays in the trigger collider.")]
    [SerializeField] string button;
    
    void Start(){}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (enterArea && other.gameObject.tag == gameObjectTag)
            EnableAction();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (exitArea && other.gameObject.tag == gameObjectTag)
            EnableAction();
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(stayInArea && Input.GetButtonDown(button) && other.gameObject.tag == gameObjectTag)
            EnableAction();
    } 
}

