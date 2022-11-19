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
    [Tooltip ("Tag of the game object that will interact with this trigger.")]
    [SerializeField] string gameObjectTag;
    [Tooltip ("Input manager button to be pressed while the game object stays in the trigger collider.")]
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

    //Fix: It seems that sometimes the input isn't recognized?
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown(button) && stayInArea && other.gameObject.tag == gameObjectTag)
            EnableAction();
    } 
}

