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
    bool inTrigger;
    
    void Awake()
    {
        inTrigger = false;
    }

    void Update()
    {
        if (button != "" && Input.GetButtonDown(button) && inTrigger)
            EnableAction();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == gameObjectTag)

            if(enterArea)
                EnableAction();

            else if(stayInArea)
                inTrigger = true;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == gameObjectTag)

            if(exitArea)
                EnableAction();
                
            else if(stayInArea)
                inTrigger = false;
    }
}